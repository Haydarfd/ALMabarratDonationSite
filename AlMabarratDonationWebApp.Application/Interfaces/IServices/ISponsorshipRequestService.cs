using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Core.Entities;

namespace AlMabarratDonationWebApp.Application.Interfaces.IServices
{
    public interface ISponsorshipRequestService
    {
        Task CreateSponsorshipRequestAsync(CreateSponsorshipRequestDto dto, string userId);
        Task<List<SponsorshipRequestDto>> GetAllAsync();
        Task<List<SponsorshipRequestDto>> GetAllWithDonorEmailAsync();
    }
}
