namespace Todo.App.Mvc.PresentationLayer.Models.ViewModels
{
    public class ToDoListViewModel
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
