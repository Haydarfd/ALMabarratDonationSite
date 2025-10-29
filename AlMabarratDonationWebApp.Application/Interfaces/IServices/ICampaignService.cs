using AlMabarratDonationWebApp.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlMabarratDonationWebApp.Application.Interfaces.IServices
{
    public interface ICampaignService
    {
        Task<CampaignDto> CreateAsync(CreateCampaignDto dto);
        Task<bool> UpdateAsync(int id, UpdateCampaignDto dto);
        Task<IEnumerable<CampaignDto>> GetAllAsync();
        Task<CampaignDto> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
