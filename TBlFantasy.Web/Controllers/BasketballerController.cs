using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TBlFantasy.Web.Controllers
{
    [Authorize]
    public class BasketballerController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
