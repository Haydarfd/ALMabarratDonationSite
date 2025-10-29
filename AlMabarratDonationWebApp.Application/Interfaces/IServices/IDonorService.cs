using AlMabarratDonationWebApp.Application.DTO;
using System.Threading.Tasks;

namespace AlMabarratDonationWebApp.Application.Interfaces.IServices
{
    public interface IDonorService
    {
        Task<int> AddDonorAsync(CreateDonorDto donorCreateDto);
        Task UpdateDonorAsync(int donorId, UpdateDonorDto donorUpdateDto);
        Task<List<DonationDto>> GetDonationsByDonorIdAsync(int donorId);
        Task<List<OrphanDto>> GetSponsoredOrphansByDonorIdAsync(int donorId);
        //Task<List<PaymentDto>> GetPaymentsByDonorIdAsync(int donorId);
        Task<List<DonationDto>> GetDonationsByDonationTypeAsync(int donorId, int donationTypeId);
        Task<List<DonorDto>> GetAllDonorsAsync();
        Task<UpdateDonorDto?> GetDonorForUpdateAsync(int donorId);
        Task<DonorDto?> GetDonorByIdAsync(int donorId);
        Task DeleteDonorAsync(int donorId, string reason);


    }

}
