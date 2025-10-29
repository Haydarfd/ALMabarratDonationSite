using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AlMabarratDonationWebApp.UI.Controllers
{
    public class DonorController : Controller
    {
        private readonly IDonorService _donorService;

        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        // GET: Donor/IndexForAdmin
        public async Task<IActionResult> IndexForAdmin()
        {
            var donors = await _donorService.GetAllDonorsAsync();
            return View("IndexForAdmin", donors);
        }

        // GET: Donor/IndexForStaff
        public async Task<IActionResult> IndexForStaff()
        {
            var donors = await _donorService.GetAllDonorsAsync();
            return View("IndexForStaff", donors);
        }

        // GET: Donor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Donor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDonorDto dto)
        {
            if (ModelState.IsValid)
            {
                await _donorService.AddDonorAsync(dto);
                return RedirectToAction(nameof(IndexForAdmin)); // Default redirect to Admin view
            }

            return View(dto);
        }

        // GET: Donor/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var donor = await _donorService.GetDonorForUpdateAsync(id);
            if (donor == null)
                return NotFound();

            return View(donor);
        }

        // POST: Donor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateDonorDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _donorService.UpdateDonorAsync(id, dto);
                return RedirectToAction(nameof(IndexForAdmin)); // Default redirect to Admin view
            }

            return View(dto);
        }

        // GET: Donor/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var donor = await _donorService.GetDonorByIdAsync(id);
            if (donor == null)
                return NotFound();

            return View(donor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _donorService.DeleteDonorAsync(id, "User requested deletion");
                return RedirectToAction(nameof(IndexForAdmin));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Failed to delete donor. Please try again.";
                return RedirectToAction(nameof(IndexForAdmin));
            }
        }
    }
}
