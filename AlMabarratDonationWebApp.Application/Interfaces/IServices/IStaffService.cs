using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Application.ViewModels;
using AlMabarratDonationWebApp.Core.Entities;

namespace AlMabarratDonationWebApp.Core.Services
{
    public interface IStaffService
    {
        Task<IEnumerable<Staff>> GetAllStaffAsync();

       
        Task<bool> CreateStaffAsync(CreateStaffDto dto);
        Task<bool> UpdateStaffAsync(int id, UpdateStaffDto dto);
        Task<bool> DeleteStaffAsync(int id);
        Task<IEnumerable<StaffViewModel>> GetAllStaffWithUsersAsync();
        Task<Staff?> GetStaffByIdAsync(int id);
    }
}
