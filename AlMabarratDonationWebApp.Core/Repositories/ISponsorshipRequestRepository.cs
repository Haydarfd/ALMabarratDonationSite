using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlMabarratDonationWebApp.Core.Repositories
{
    public interface ISponsorshipRequestRepository : IRepository<SponsorshipRequest>
    {
        Task<List<SponsorshipRequest>> GetAllWithDonorAsync();
    }
}
