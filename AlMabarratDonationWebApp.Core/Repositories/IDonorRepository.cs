using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Core.Repositories.Base;

namespace AlMabarratDonationWebApp.Core.Repositories
{
    public interface IDonorRepository : IRepository<Donor>
    {
        List<Orphan> GetSponsoredOrphansByDonorId(int donorId);
        //List<Sponsorship> GetSponsorshipHistory(int donorId, DateTime? startDate = null, DateTime? endDate = null);
       
        
        decimal GetTotalDonationsAmount(int donorId);
        decimal GetTotalSponsorshipAmount(int donorId);
        int GetSponsoredOrphansCount(int donorId);
        List<Donation> GetDonationHistory(int donorId, DateTime? startDate = null, DateTime? endDate = null);
        List<Payment> GetPaymentHistory(int donorId, DateTime? startDate = null, DateTime? endDate = null);
        List<Donor> SearchDonors(string searchTerm);
    }
}
