using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Todo.App.Mvc.BusinessLayer.Abstract;
using ToDo.App.Mvc.EntityLayer.Concrete;

namespace Todo.App.Mvc.PresentationLayer.Controllers
{
    public class AppLayoutController : Controller
    {
        private readonly IToDoCategoryService _toDoCategoryService;

        public AppLayoutController(IToDoCategoryService toDoCategoryService)
        {
            _toDoCategoryService = toDoCategoryService;
        }

        public IActionResult _AppLayout()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var values = _toDoCategoryService.TGetByUserId(userId);
            return View(values);
        } 
 
        public IActionResult HeadPartial()
        {
            return View();
        }

        public IActionResult SidebarCategoryAddPartial()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SidebarPartial()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var values = _toDoCategoryService.TGetByUserId(userId);
            return PartialView("SidebarPartial", values);
        }

        public IActionResult HeaderPartial()
        {
            return View();
        }

        public IActionResult ScriptPartial()
        {
            return View();
        }
    }
}
