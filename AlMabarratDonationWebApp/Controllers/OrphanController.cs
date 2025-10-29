using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Application.Services;
using AlMabarratDonationWebApp.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AlMabarratDonationWebApp.Web.Controllers
{
    [Authorize]
    public class OrphanController : Controller
    {
        private readonly IOrphanService _orphanService;

        public OrphanController(IOrphanService orphanService)
        {
            _orphanService = orphanService;
        }

        // ========== NEW ACTION FOR ADMIN ==========
        [HttpGet]
        public async Task<IActionResult> IndexForAdmin()
        {
            var orphans = await _orphanService.GetAllAsync();
            ViewBag.Nationalities = await _orphanService.GetAllNationalityNamesAsync();
            return View("IndexForAdmin", orphans);
        }

        // ========== NEW ACTION FOR STAFF ==========
        [HttpGet]
        public async Task<IActionResult> IndexForStaff()
        {
            var orphans = await _orphanService.GetAllAsync();
            ViewBag.Nationalities = await _orphanService.GetAllNationalityNamesAsync();
            return View("IndexForStaff", orphans);
        }


        [HttpGet]
        public async Task<IActionResult> FetchOrphansForSponsorship(int sponsorshipRequestId, string donorEmail)
        {
            var orphans = await _orphanService.GetAllAsync();

            if (orphans == null || orphans.Count == 0)
            {
                ViewBag.ErrorMessage = "No orphans available.";
                return View("~/Views/Sponsorship/SelectOrphans.cshtml", new List<OrphanDto>());
            }

            ViewBag.SponsorshipRequestId = sponsorshipRequestId;
            ViewBag.DonorEmail = donorEmail;
            return View("~/Views/Sponsorship/SelectOrphans.cshtml", orphans);
        }



        public async Task<IActionResult> Create()
        {
            var nationalities = await _orphanService.GetAllNationalityNamesAsync();
            var viewModel = new CreateOrphanViewModel
            {
                NationalityOptions = nationalities
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrphanDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Nationalities = await _orphanService.GetAllNationalityNamesAsync();
                return View(dto);
            }

            await _orphanService.CreateAsync(dto);
            return RedirectToAction(nameof(IndexForAdmin)); // Redirect to the correct Index after creation
        }

        public async Task<IActionResult> Edit(int id)
        {
            var orphan = await _orphanService.GetByIdAsync(id);
            if (orphan == null) return NotFound();

            var nationalities = await _orphanService.GetAllNationalityNamesAsync();

            var viewModel = new CreateOrphanViewModel
            {
                OrphanID = orphan.OrphanID,
                FullName = orphan.FullName,
                DateOfBirth = orphan.DateOfBirth,
                Gender = orphan.Gender,
                Age = orphan.Age,
                LostParents = orphan.LostParents,
                Status = orphan.Status,
                DateJoined = orphan.DateJoined,
                FatherName = orphan.FatherName,
                MotherName = orphan.MotherName,
                Nationality = orphan.Nationality,
                HealthCondition = orphan.HealthCondition,
                NationalityOptions = nationalities
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateOrphanViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Nationalities = await _orphanService.GetAllNationalityNamesAsync();
                return View(viewModel);
            }

            var dto = new UpdateOrphanDto
            {
                OrphanID = viewModel.OrphanID,
                FullName = viewModel.FullName,
                DateOfBirth = viewModel.DateOfBirth,
                Gender = viewModel.Gender,
                Age = viewModel.Age,
                LostParents = viewModel.LostParents,
                Status = viewModel.Status,
                DateJoined = viewModel.DateJoined,
                FatherName = viewModel.FatherName,
                MotherName = viewModel.MotherName,
                Nationality = viewModel.Nationality,
                HealthCondition = viewModel.HealthCondition
            };

            var updated = await _orphanService.UpdateAsync(dto);
            if (updated == null) return NotFound();

            return RedirectToAction(nameof(IndexForAdmin)); // Redirect to the correct view
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _orphanService.DeleteAsync(id);
            if (!deleted) return NotFound();

            return RedirectToAction(nameof(IndexForAdmin)); // Redirect to the correct view
        }

        public async Task<IActionResult> Details(int id)
        {
            var orphan = await _orphanService.GetByIdAsync(id);
            if (orphan == null) return NotFound();

            return View(orphan);
        }
    }
}
