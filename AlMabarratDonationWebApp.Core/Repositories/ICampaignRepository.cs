using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Core.Repositories.Base;

namespace AlMabarratDonationWebApp.Core.Repositories
{
    public interface ICampaignRepository : IRepository<Campaign>
    {
        decimal GetTotalDonations(int campaignId);
        void UpdateCampaignProgress(int campaignId);
        bool IsTargetReached(int campaignId);
        public List<Campaign> GetActiveCampaigns(bool includeExpired = false);
    }
}
