using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.App.Mvc.EntityLayer.Concrete;

namespace Todo.App.Mvc.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, string>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }

        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoCategory> ToDoCategories { get; set; }
    }
}
