using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using AlMabarratDonationWebApp.Core.Repositories;
using AlMabarratDonationWebApp.Infrastructure.Data;
using AlMabarratDonationWebApp.Infrastructure.Repositories.Base;

namespace AlMabarratDonationWebApp.Infrastructure.Repositories
{
    public class SponsorshipRequestRepository : Repository<SponsorshipRequest>, ISponsorshipRequestRepository
    {
        public SponsorshipRequestRepository(AlMabarratDonationWebApp.Infrastructure.Data.AppDbContext context)
             : base(context)
        {
        }


        public async Task<List<SponsorshipRequest>> GetAllWithDonorAsync()
        {
            var sponsorshipRequests = await _context.SponsorshipRequests
                .Include(sr => sr.AppUser)  // <-- This will join the AspNetUsers
                .ToListAsync();

            return sponsorshipRequests;
        }

    
    }
}
