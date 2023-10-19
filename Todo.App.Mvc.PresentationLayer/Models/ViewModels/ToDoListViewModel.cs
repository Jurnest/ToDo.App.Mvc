namespace Todo.App.Mvc.PresentationLayer.Models.ViewModels
{
    public class ToDoListViewModel
    {
        public string? Title { get; set; }
        public DateTime? PlannedEndDate { get; set; }
        public string? UserId { get; set; }
        public int? TodoCategoryId { get; set; }
    }
}
