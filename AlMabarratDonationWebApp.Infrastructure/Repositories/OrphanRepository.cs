using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Core.Repositories;
using AlMabarratDonationWebApp.Infrastructure.Data;
using AlMabarratDonationWebApp.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

public class OrphanRepository : Repository<Orphan>, IOrphanRepository
{
    public OrphanRepository(AppDbContext context) : base(context) { }

    public async Task<List<Orphan>> GetSponsoredOrphansAsync()
    {
        return await _context.Orphans
            .Where(o => o.IsSponsored && !o.IsDeleted)
            .ToListAsync();
    }

    public async Task<List<Orphan>> GetUnsponsoredOrphansAsync()
    {
        return await _context.Orphans
            .Where(o => !o.IsSponsored && !o.IsDeleted)
            .ToListAsync();
    }

    public async Task<List<Orphan>> GetOrphansByAgeRangeAsync(int minAge, int maxAge)
    {
        return await _context.Orphans
            .Where(o => o.Age >= minAge && o.Age <= maxAge && !o.IsDeleted)
            .ToListAsync();
    }

    public async Task<List<Orphan>> GetOrphansByDonorIdAsync(int donorId)
    {
        return await _context.Sponsorships
            .Where(s => s.DonorID == donorId)
            .Select(s => s.Orphan)
            .Where(o => o != null && !o.IsDeleted)
            .ToListAsync();
    }

    public async Task<Donor> GetSponsorByOrphanIdAsync(int orphanId)
    {
        var sponsorship = await _context.Sponsorships
            .Include(s => s.Donor)
            .FirstOrDefaultAsync(s => s.OrphanID == orphanId);

        return sponsorship?.Donor!;
    }

    public void AssignSponsor(int orphanId, int donorId)
    {
        var sponsorship = new Sponsorship
        {
            OrphanID = orphanId,
            DonorID = donorId,
            //StartDate = DateOnly.FromDateTime(DateTime.Now)
        };

        _context.Sponsorships.Add(sponsorship);

        var orphan = _context.Orphans.Find(orphanId);
        if (orphan != null)
        {
            orphan.IsSponsored = true;
            _context.Orphans.Update(orphan);
        }

        _context.SaveChanges();
    }

    public void RemoveSponsor(int orphanId)
    {
        var sponsorships = _context.Sponsorships.Where(s => s.OrphanID == orphanId).ToList();
        if (sponsorships.Any())
        {
            _context.Sponsorships.RemoveRange(sponsorships);
        }

        var orphan = _context.Orphans.Find(orphanId);
        if (orphan != null)
        {
            orphan.IsSponsored = false;
            _context.Orphans.Update(orphan);
        }

        _context.SaveChanges();
    }
}
