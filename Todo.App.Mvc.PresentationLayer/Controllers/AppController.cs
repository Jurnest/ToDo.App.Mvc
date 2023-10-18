using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Todo.App.Mvc.BusinessLayer.Abstract;
using ToDo.App.Mvc.EntityLayer.Concrete;

namespace Todo.App.Mvc.PresentationLayer.Controllers
{
    public class AppController : Controller
    {
        private readonly IToDoListService _toDoListService;
        private readonly IToDoCategoryService _toDoCategoryService;
        private readonly UserManager<AppUser> _userManager;

        public AppController(IToDoListService toDoListService, UserManager<AppUser> userManager, IToDoCategoryService toDoCategoryService)
        {
            _toDoListService = toDoListService;
            _userManager = userManager;
            _toDoCategoryService = toDoCategoryService;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var toDoLists = _toDoListService.TGetByUserId(userId);
            var value = toDoLists.Find(x => x.TodoCategoryId == id);
            var toDoCategories = _toDoCategoryService.TGetByUserId(userId);
            ViewBag.UserId = userId;
            if (value != null)
            {
                return View(new Tuple<List<ToDoList>, List<ToDoCategory>, List<ToDoList>>(toDoLists, toDoCategories, value));
            }
            return View(new Tuple<List<ToDoList>, List<ToDoCategory>>(toDoLists, toDoCategories));
        }


        [HttpGet]
        public IActionResult AddToDo()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.UserId = userId;
            return View();
        }

        [HttpPost]
        public IActionResult AddToDo(ToDoList toDoList)
        {
            if (toDoList.IsDone == true)
            {
                toDoList.EndDate = DateTime.Now;
            }
            _toDoListService.TInsert(toDoList);

            return RedirectToAction("Index", "App");
        }

        [HttpPut]
        public IActionResult UpdateToDo()
        {
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
