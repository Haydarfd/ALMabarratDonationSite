
using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Application.Interfaces.IServices;
using AlMabarratDonationWebApp.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AlMabarratDonationWebApp.Controllers
{
    [Authorize]
    public class SponsorshipRequestController : Controller
    {
        private readonly ISponsorshipRequestService _sponsorshipRequestService;
        private readonly IOrphanService _orphanService;
        // private object orphanService;

        public SponsorshipRequestController(ISponsorshipRequestService sponsorshipRequestService, IOrphanService orphanService)
        {
            _sponsorshipRequestService = sponsorshipRequestService ?? throw new ArgumentNullException(nameof(sponsorshipRequestService));
            _orphanService = orphanService ?? throw new ArgumentNullException(nameof(orphanService));
        }





        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sponsorshipRequests = await _sponsorshipRequestService.GetAllAsync();

            if (sponsorshipRequests == null || !sponsorshipRequests.Any())
            {
                ViewBag.ErrorMessage = "No sponsorship requests available.";
            }

            return View("Index", sponsorshipRequests);
        }


        [HttpPost]
        public IActionResult Assign(int id)
        {
            // Call your service method to assign the sponsorship
            // Example: _sponsorshipService.AssignSponsorship(id);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Unassign(int id)
        {
            // Call your service method to unassign the sponsorship
            // Example: _sponsorshipService.UnassignSponsorship(id);

            return Json(new { success = true });
        }

        //[HttpGet]
        //public async Task<IActionResult> SelectOrphans(int sponsorshipRequestId, string donorEmail)
        //{
        //    // Fetch the list of all orphans
        //    var orphans = await _orphanService.GetAllAsync();



        //    // Pass the SponsorshipRequestId and DonorEmail to the view
        //    ViewBag.SponsorshipRequestId = sponsorshipRequestId;
        //    ViewBag.DonorEmail = donorEmail;


        //    return View("~/Views/Sponsorship/SelectOrphans.cshtml", orphans);
        //}
        [HttpGet]
        public IActionResult SelectOrphans(int sponsorshipRequestId, string donorEmail)
        {
            return RedirectToAction("FetchOrphansForSponsorship", "Orphan", new { sponsorshipRequestId = sponsorshipRequestId, donorEmail = donorEmail });
        }


    }
}
