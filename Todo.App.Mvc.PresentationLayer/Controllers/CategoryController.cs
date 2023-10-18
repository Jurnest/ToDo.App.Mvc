using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Todo.App.Mvc.BusinessLayer.Abstract;
using ToDo.App.Mvc.EntityLayer.Concrete;

namespace Todo.App.Mvc.PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IToDoCategoryService _toDoCategoryService;
        private readonly UserManager<AppUser> _userManager;

        public CategoryController(UserManager<AppUser> userManager, IToDoCategoryService toDoCategoryService)
        {
            _userManager = userManager;
            _toDoCategoryService = toDoCategoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var values = _toDoCategoryService.TGetByUserId(userId);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.UserId = userId;
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(ToDoCategory toDoCategory)
        {
            _toDoCategoryService.TInsert(toDoCategory);

            return RedirectToAction("Index", "Category");
        }
    }
}
