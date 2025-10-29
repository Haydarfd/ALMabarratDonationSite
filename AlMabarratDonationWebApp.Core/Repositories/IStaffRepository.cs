using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Core.Repositories.Base;
using System.Collections.Generic;
namespace AlMabarratDonationWebApp.Core.Repositories
{
    public interface IStaffRepository : IRepository<Staff>
    {
        // Activation Management
        Task DeactivateStaffAsync(int staffId);
        Task ReactivateStaffAsync(int staffId);

        // Filtering
        Task<List<Staff>> GetActiveStaffAsync();
        Task<List<Staff>> GetInactiveStaffAsync();

        // Security
        Task ResetPasswordHashAsync(int staffId, string newPasswordHash);

        // Lookup
        Task<Staff?> GetByUserIdAsync(string userId);
        Task<IEnumerable<Staff>> GetAllWithUsersAsync();
        Task<Staff?> GetStaffWithUserAsync(int id);
        
    }
}
