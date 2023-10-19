using ToDo.App.Mvc.EntityLayer.Concrete;

namespace Todo.App.Mvc.PresentationLayer.Models.ViewModels
{
    public class SidebarViewsModels
    {
        public List<ToDoCategory> Categories { get; set; }
        public List<ToDoList> ToDoLists { get; set; }
        public ToDoList toDoListViewModel { get; set; }
        public ToDoCategoryAddViewModel AddCategory { get; set; }
    }
}
