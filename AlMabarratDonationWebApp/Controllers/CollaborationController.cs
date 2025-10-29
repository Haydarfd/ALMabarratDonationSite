using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlMabarratDonationWebApp.Controllers
{

    public class CollaborationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
