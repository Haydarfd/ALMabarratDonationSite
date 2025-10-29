using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Core.Repositories;
using AlMabarratDonationWebApp.Infrastructure.Data;
using AlMabarratDonationWebApp.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AlMabarratDonationWebApp.Infrastructure.Repositories
{
    public class CampaignRepository : Repository<Campaign>, ICampaignRepository
    {
        private readonly AppDbContext _context;

        public CampaignRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public List<Campaign> GetActiveCampaigns(bool includeExpired = false)
        {
            var query = _context.Campaigns.AsQueryable();



            //if (!includeExpired)
            //{
            //    query = query.Where(c =>
            //        (c.TargetAmount ?? 0) > (c.CurrentAmount ?? 0)
            //    );
            //}

            return query.ToList();
        }

        public decimal GetTotalDonations(int campaignId)
        {
            var campaign = _context.Campaigns.Find(campaignId);
            return campaign?.CurrentAmount ?? 0m;
        }

        public async Task<decimal> GetTotalDonationsAsync(int campaignId)
        {
            var campaign = await _context.Campaigns.FindAsync(campaignId);
            return campaign?.CurrentAmount ?? 0m;
        }

        public bool IsTargetReached(int campaignId)
        {
            var campaign = _context.Campaigns.Find(campaignId);
            if (campaign == null) return false;
            return true;
        }
        public void UpdateCampaignProgress(int campaignId)
        {
            var campaign = _context.Campaigns.Find(campaignId);
            if (campaign != null)
            {

                //campaign.CurrentAmount += newDonationAmount;

                // Or just re-save the current value if updated elsewhere
                _context.SaveChanges();
            }
        }

    }
}
