using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Core.Repositories;
using AlMabarratDonationWebApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AlMabarratDonationWebApp.Infrastructure.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly AppDbContext _context;

        public DonorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Donor>> GetAllAsync()
        {
            return await _context.Donors
                .Where(d => !d.IsDeleted) 
                .Include(d => d.AppUser)
                .ToListAsync();
        }
 

        public async Task<IReadOnlyList<Donor>> GetAsync(Expression<Func<Donor, bool>> predicate)
        {
            return await _context.Donors.Where(predicate).ToListAsync();
        }

        public async Task<Donor> GetByIdAsync(int id)
        {
            return await _context.Donors
                    .Where(d => !d.IsDeleted) 
                .Include(d => d.Donations)
                .Include(d => d.Payments)
                .Include(d => d.Sponsorships)
                //.Include(d => d.Orphans)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Donor> AddAsync(Donor entity)
        {
            _context.Donors.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Donor entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Donor entity)
        {
            // Convert to soft delete implementation
            entity.IsDeleted = true;
            entity.DeletionDate = DateTime.UtcNow;
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
        public List<Orphan> GetSponsoredOrphansByDonorId(int donorId)
        {
            return _context.Orphans
                //.Where(o => o.DonorID == donorId && o.IsActive)
                .ToList();
        }

        //public List<Sponsorship> GetSponsorshipHistory(int donorId, DateTime? startDate = null, DateTime? endDate = null)
        //{
        //    var query = _context.Sponsorships
        //        .Where(s => s.DonorID == donorId);

        //    if (startDate.HasValue)
        //        query = query.Where(s => EF.Property<DateTime>(s, "Date") >= startDate.Value); // if you have a Date field in Sponsorship
        //    if (endDate.HasValue)
        //        query = query.Where(s => EF.Property<DateTime>(s, "Date") <= endDate.Value);

        //    return query.ToList();
        //}

        public decimal GetTotalDonationsAmount(int donorId)
        {
            return _context.Donations
                .Where(d => d.DonorId == donorId)
                .Sum(d => (decimal?)d.Amount) ?? 0m;
        }

        public decimal GetTotalSponsorshipAmount(int donorId)
        {
            return _context.Sponsorships
                .Where(s => s.DonorID == donorId)
                .Sum(s => (decimal?)s.Amount) ?? 0m;
        }

        public int GetSponsoredOrphansCount(int donorId)
        {
            return _context.Orphans
                //.Where(o => o.DonorID == donorId)
                .Count();
        }

        public List<Donation> GetDonationHistory(int donorId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.Donations
                .Where(d => d.DonorId == donorId);

            if (startDate.HasValue)
                query = query.Where(d => d.Date >= startDate.Value);
            if (endDate.HasValue)
                query = query.Where(d => d.Date <= endDate.Value);

            return query.ToList();
        }

        public List<Payment> GetPaymentHistory(int donorId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.Payments
                .Where(p => p.DonorId == donorId);

            if (startDate.HasValue)
                query = query.Where(p => p.Date >= startDate.Value);
            if (endDate.HasValue)
                query = query.Where(p => p.Date <= endDate.Value);

            return query.ToList();
        }

        public List<Donor> SearchDonors(string searchTerm)
        {
            return _context.Donors
                .Include(d => d.AppUser)
                .Where(d =>
                    d.AppUserId.Contains(searchTerm) ||
                    d.Address.Contains(searchTerm) ||
                    d.City.Contains(searchTerm) ||
                    d.Country.Contains(searchTerm)
                )
                .ToList();
        }
    }
}
