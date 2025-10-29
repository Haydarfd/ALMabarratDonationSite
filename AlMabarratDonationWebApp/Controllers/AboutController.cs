using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlMabarratDonationWebApp.Controllers
{

    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
