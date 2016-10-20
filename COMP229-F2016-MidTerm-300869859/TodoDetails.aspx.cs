using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMP229_F2016_MidTerm_300869859.Models;

namespace COMP229_F2016_MidTerm_300869859
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to the list page
            Response.Redirect("~/TodoList.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to conect to the server
            using (TodoContext db = new TodoContext())
            {
                // use the model to create a new student object and 
                // save a new record

                Todo newTodo = new Todo();

                int TodoID = 0;

                if (Request.QueryString.Count > 0) // our URL has a STUDENTID in it
                {
                    // get the id from the URL
                }

                // add form data to the new student record
                newTodo.TodoDescription = TodoDescriptionTextBox.Text;
                newTodo.TodoNotes = TodoNotesTextBox.Text;
                // use LINQ to ADO.NET to add / insert new todo into the db

                if (TodoID == 0)
                {
                    db.Todos.Add(newTodo);
                }

                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated students page
                Response.Redirect("~/TodoList.aspx");
            }
        }
    }
}