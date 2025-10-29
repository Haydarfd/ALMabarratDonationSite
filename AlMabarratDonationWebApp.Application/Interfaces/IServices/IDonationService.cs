using AlMabarratDonationWebApp.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlMabarratDonationWebApp.Application.Interfaces.IServices
{
    public interface IDonationService
    {
        Task<List<DonationDto>> GetAllDonationsAsync();
        Task<DonationDto> GetDonationByIdAsync(int donationId);
        Task<int> AddDonationAsync(CreateDonationDto createDonationDto);
        Task UpdateDonationAsync(int donationId, UpdateDonationDto updateDonationDto);
        Task DeleteDonationAsync(int donationId);
    }

}
