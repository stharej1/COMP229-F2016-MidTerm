using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMP229_F2016_MidTerm_300869859.Models;

namespace COMP229_F2016_MidTerm_300869859
{
    public partial class TodoList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Get the data
                this.GetTodoList();
            }
        }

        private void GetTodoList()
        {
            // connect to EF DB
            using (TodoContext db = new TodoContext())
            {
                // query the Todo Table using EF and LINQ
                var List = (from allLists in db.Todos
                            select allLists);

                // bind the result to the GridView
                GridView.DataSource = List.ToList();
                GridView.DataBind();
            }
        }
        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get the selected TodoId using the Grid's DataKey collection
            int TodoID = Convert.ToInt32(GridView.DataKeys[selectedRow].Values["TodoID"]);

            // use EF and LINQ to find the selected student in the DB and remove it
            using (TodoContext db = new TodoContext())
            {
                // create object ot the todo clas and store the query inside of it
                Todo deletedRow = (from Records in db.Todos
                                   where Records.TodoID == TodoID
                                   select Records).FirstOrDefault();

                // remove the selected student from the db
                db.Todos.Remove(deletedRow);

                // save my changes back to the db
                db.SaveChanges();

                // refresh the grid
                this.GetTodoList();
            }


        }
    }
}