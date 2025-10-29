using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Core.Repositories;
using AlMabarratDonationWebApp.Core.Services;
using Microsoft.AspNetCore.Identity;
using AlMabarratDonationWebApp.Application.ViewModels;


namespace AlMabarratDonationWebApp.Service.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly UserManager<AppUser> _userManager;

        public StaffService(IStaffRepository staffRepository, UserManager<AppUser> userManager)
        {
            _staffRepository = staffRepository;
            _userManager = userManager;
        }
       
        public async Task<IEnumerable<Staff>> GetAllStaffAsync()
        {
            return await _staffRepository.GetAllAsync();
        }

        public async Task<Staff?> GetStaffByIdAsync(int id)
        {
            return await _staffRepository.GetStaffWithUserAsync(id);
        }
        public async Task<bool> CreateStaffAsync(CreateStaffDto dto)
        {
            var user = new AppUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                FullName = dto.FullName,
                Address = dto.Address,
                City = dto.City,
                PostalCode = dto.PostalCode,
                Country = dto.Country,
                UserType = "Staff",
                EmailConfirmed = true // ✅ Confirm email so the user can log in
            };

            var result = await _userManager.CreateAsync(user, dto.TemporaryPassword);
            if (!result.Succeeded)
            {
                // Optionally log result.Errors here
                return false;
            }

            // ✅ Assign the "Staff" role
            await _userManager.AddToRoleAsync(user, "Staff");

            var staff = new Staff
            {
                UserID = user.Id,
                JoinDate = DateOnly.FromDateTime(dto.JoinDate),
                IsActive = dto.IsActive,
                RequiresPasswordChange = true
            };

            await _staffRepository.AddAsync(staff);
            return true;
        }



        public async Task<bool> UpdateStaffAsync(int id, UpdateStaffDto dto)
        {
            var staff = await _staffRepository.GetByIdAsync(id);
            if (staff == null) return false;

            // Update Staff fields
            staff.IsActive = dto.IsActive;
            staff.RequiresPasswordChange = dto.RequiresPasswordChange;

            // Update User fields
            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null) return false;

            user.FullName = dto.FullName;
            user.Email = dto.Email;
            user.UserName = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;
            user.Address = dto.Address;
            user.City = dto.City;
            user.PostalCode = dto.PostalCode;
            user.Country = dto.Country;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                // Optional: log result.Errors
                return false;
            }

            // Handle password reset
            if (!string.IsNullOrEmpty(dto.NewPassword))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResult = await _userManager.ResetPasswordAsync(user, token, dto.NewPassword);
                if (!passwordResult.Succeeded)
                {
                    // Optional: log passwordResult.Errors
                    return false;
                }

                staff.RequiresPasswordChange = true;
            }

            await _staffRepository.UpdateAsync(staff);
            return true;
        }



        public async Task<bool> DeleteStaffAsync(int id)
        {
            var staff = await _staffRepository.GetByIdAsync(id);
            if (staff == null) return false;

            return await _staffRepository.DeleteAsync(staff);
        }
        public async Task<IEnumerable<StaffViewModel>> GetAllStaffWithUsersAsync()
        {
            var staffList = await _staffRepository.GetAllWithUsersAsync();

            return staffList.Select(s => new StaffViewModel
            {
                StaffID = s.StaffID,
                JoinDate = s.JoinDate,
                IsActive = s.IsActive,
                RequiresPasswordChange = s.RequiresPasswordChange,

                FullName = s.User.FullName,
                Email = s.User.Email,
                PhoneNumber = s.User.PhoneNumber,
                Address = s.User.Address,
                City = s.User.City,
                PostalCode = s.User.PostalCode,
                Country = s.User.Country
            });
        }


    }
}
