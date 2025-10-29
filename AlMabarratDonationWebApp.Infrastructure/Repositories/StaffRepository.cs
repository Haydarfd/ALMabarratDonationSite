using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Core.Repositories;
using AlMabarratDonationWebApp.Infrastructure.Data;
using AlMabarratDonationWebApp.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AlMabarratDonationWebApp.Infrastructure.Repositories
{
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        private readonly AppDbContext _context;

        public StaffRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task DeactivateStaffAsync(int staffId)
        {
            var staff = await _context.Staff.FindAsync(staffId);
            if (staff != null)
            {
                staff.IsActive = false;
                _context.Update(staff);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ReactivateStaffAsync(int staffId)
        {
            var staff = await _context.Staff.FindAsync(staffId);
            if (staff != null)
            {
                staff.IsActive = true;
                _context.Update(staff);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Staff>> GetActiveStaffAsync()
        {
            return await _context.Staff
                .Include(s => s.User)
                .Where(s => s.IsActive)
                .ToListAsync();
        }

        public async Task<List<Staff>> GetInactiveStaffAsync()
        {
            return await _context.Staff
                .Include(s => s.User)
                .Where(s => !s.IsActive)
                .ToListAsync();
        }

        public async Task ResetPasswordHashAsync(int staffId, string newPasswordHash)
        {
            var staff = await _context.Staff
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.StaffID == staffId);

            if (staff != null && staff.User != null)
            {
                staff.User.PasswordHash = newPasswordHash;
                staff.RequiresPasswordChange = true;
                _context.Update(staff);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Staff?> GetByUserIdAsync(string userId)
        {
            return await _context.Staff
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.UserID == userId);
        }

        public async Task<IEnumerable<Staff>> GetAllWithUsersAsync()
        {
            return await _context.Staff
                .Include(s => s.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Staff>> GetAllAsync()
        {
            return await _context.Staff
                .Include(s => s.User)  
                .ToListAsync();
        }

 


        public async Task<Staff?> GetStaffWithUserAsync(int id)
        {
            return await _context.Staff
                .Include(s => s.User)  // Eager load the related User data
                .AsNoTracking()       // Recommended for read-only operations
                .FirstOrDefaultAsync(s => s.StaffID == id);
        }
    }
}
