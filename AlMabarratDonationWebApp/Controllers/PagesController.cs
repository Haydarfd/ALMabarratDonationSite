using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlMabarratDonationWebApp.Controllers
{

    public class PagesController : Controller
    {
        public IActionResult SuccessStories()
        {
            return View();
        }
        public IActionResult SuccessStoriesDetails()
        {
            return View();
        }
        public IActionResult PricingPackages()
        {
            return View();
        }
    }
}
