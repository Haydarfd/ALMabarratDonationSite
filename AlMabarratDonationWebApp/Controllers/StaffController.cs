using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AlMabarratDonationWebApp.Core.Entities;
using System.Data.Entity;

namespace AlMabarratDonationWebApp.Web.Controllers
{
    [Authorize(Roles = "Staff,Admin")]
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public StaffController(IStaffService staffService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _staffService = staffService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var staffList = await _staffService.GetAllStaffWithUsersAsync(); // now returning ViewModel
            return View(staffList); // pass the ViewModel directly
        }

        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStaffDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var existingUserByEmail = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUserByEmail != null)
            {
                ModelState.AddModelError("Email", "The email address is already in use.");
                return View(dto);
            }

            var users = _userManager.Users.ToList(); // Load into memory first
            var existingUserByPhone = users.FirstOrDefault(u => u.PhoneNumber == dto.PhoneNumber);

            if (existingUserByPhone != null)
            {
                ModelState.AddModelError("PhoneNumber", "The phone number is already in use.");
                return View(dto);
            }

            var result = await _staffService.CreateStaffAsync(dto);
            if (!result)
            {
                ModelState.AddModelError("", "Failed to create staff member.");
                return View(dto);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var staff = await _staffService.GetStaffByIdAsync(id);
            if (staff == null)
                return NotFound();

            var dto = _mapper.Map<UpdateStaffDto>(staff);
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateStaffDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _staffService.UpdateStaffAsync(id, dto);
            if (!result)
            {
                ModelState.AddModelError("", "Failed to update staff.");
                return View(dto);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _staffService.DeleteStaffAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
