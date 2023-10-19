using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using Todo.App.Mvc.BusinessLayer.Abstract;
using Todo.App.Mvc.PresentationLayer.Models.ViewModels;
using ToDo.App.Mvc.EntityLayer.Concrete;

namespace Todo.App.Mvc.PresentationLayer.Controllers
{
    [Authorize]
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
            IEnumerable<ToDoList> result = null;

            if (id != null)
            {
                var toDoLists = _toDoListService.TGetByUserId(userId);
                result = toDoLists.ToList().Where(x => x.TodoCategoryId.ToString() == id.ToString());
            }
            else
            {
                result = new List<ToDoList>();
            }

            var toDoCategories = _toDoCategoryService.TGetByUserId(userId);
            ViewBag.UserId = userId;
            ViewBag.CategoryId = id;
            var sidebarViewsModels = new SidebarViewsModels();
            sidebarViewsModels.ToDoLists = result.ToList();
            sidebarViewsModels.Categories = toDoCategories;
            return View(sidebarViewsModels);
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

            return RedirectToAction("Index", "App");
        }


        public IActionResult DeleteCategory(int id)
        {
            var value = _toDoCategoryService.TGetById(id);
            if (value == null)
            {
                return RedirectToAction("Index");
            }
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;


            if (userId != value.UserId)
            {
                return RedirectToAction("Index");
            }

            _toDoCategoryService.TDelete(value);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteToDo(int id)
        {
            var value = _toDoListService.TGetById(id);
            if (value == null)
            {
                return RedirectToAction("Index");
            }
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;


            if (userId != value.UserId)
            {
                return RedirectToAction("Index");
            }

            _toDoListService.TDelete(value);
            return RedirectToAction("Index", new { id = value.TodoCategoryId });

        }

        [HttpGet]
        public IActionResult CreateToDo(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.UserId = userId;
            return View();
        }

        [HttpPost]
        public IActionResult CreateToDo(SidebarViewsModels model)
        {
            var category = _toDoCategoryService.TGetById(model.toDoListViewModel.TodoCategoryId);
            var toDoListViewModel = new ToDoList()
            {
                Title = model.toDoListViewModel.Title,
                PlannedEndDate = model.toDoListViewModel.PlannedEndDate,
                UserId = model.toDoListViewModel.UserId,
            };
            
            toDoListViewModel.ToDoCategories = category;

            _toDoListService.TInsert(toDoListViewModel);

            return RedirectToAction("Index", new { id = model.toDoListViewModel.TodoCategoryId });
        }
    }
}
