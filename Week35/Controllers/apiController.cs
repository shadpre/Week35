using Microsoft.AspNetCore.Mvc;

namespace Week35.Controllers
{
    public class apiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
