using ToDo.App.Mvc.EntityLayer.Concrete;

namespace Todo.App.Mvc.PresentationLayer.Models.ViewModels
{
    public class SidebarViesModels
    {
        public List<ToDoCategory> Categories { get; set; }
        public ToDoCategory Category { get; set; }
    }
}
