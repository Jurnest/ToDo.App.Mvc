using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.App.Mvc.EntityLayer.Concrete
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool? IsDone { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? PlannedEndDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string UserId { get; set; }
    }
}
