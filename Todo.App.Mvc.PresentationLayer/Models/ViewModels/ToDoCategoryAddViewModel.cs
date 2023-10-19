using System.ComponentModel.DataAnnotations;

namespace Todo.App.Mvc.PresentationLayer.Models.ViewModels
{
    public class ToDoCategoryAddViewModel
    {
        [Required(ErrorMessage = "This Place is Required.")]
        public string Title { get; set; }
        public string UserId { get; set; }
    }
}
