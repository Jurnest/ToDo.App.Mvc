using Microsoft.AspNetCore.Mvc;

namespace Todo.App.Mvc.PresentationLayer.Controllers
{
    public class EmptyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
