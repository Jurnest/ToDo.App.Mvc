using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.App.Mvc.EntityLayer.Concrete
{
    public class ToDoCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public virtual List<ToDoList> ToDoLists { get; set; }
    }
}
