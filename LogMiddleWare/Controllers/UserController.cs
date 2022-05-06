using Microsoft.AspNetCore.Mvc;

namespace LogMiddleWare.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index(int id)
        {
            return View(id);
        }
    }
}
