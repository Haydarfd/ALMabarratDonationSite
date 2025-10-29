using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Application.Interfaces.IServices;
using AlMabarratDonationWebApp.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AlMabarratDonationWebApp.Controllers
{
    [Authorize]
    public class SponsorshipController : Controller
    {
        private readonly ISponsorshipRequestService _sponsorshipRequestService;

        public SponsorshipController(ISponsorshipRequestService sponsorshipRequestService)
        {
            _sponsorshipRequestService = sponsorshipRequestService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CreateSponsorshipRequestDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            if (userId == null)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }


            dto.RequestedOn = DateTime.Now;
            dto.IsHandled = false;

            await _sponsorshipRequestService.CreateSponsorshipRequestAsync(dto, userId);

            TempData["Success"] = "Your sponsorship request has been submitted.";
            return RedirectToAction("Index");
        }

       

    }
}
