namespace COMP229_F2016_MidTerm_300869859.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TodoContext : DbContext
    {
        public TodoContext()
            : base("name=TodoContext1")
        {
        }

        public virtual DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
