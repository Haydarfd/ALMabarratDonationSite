using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Application.Interfaces.IServices;
using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Core.Repositories.Base;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlMabarratDonationWebApp.Application.Services
{
    public class DonationService : IDonationService
    {
        private readonly IRepository<Donation> _donationRepository;
        private readonly IMapper _mapper;

        public DonationService(IRepository<Donation> donationRepository, IMapper mapper)
        {
            _donationRepository = donationRepository;
            _mapper = mapper;
        }

        public async Task<List<DonationDto>> GetAllDonationsAsync()
        {
            var donations = await _donationRepository.GetAllAsync();
            return _mapper.Map<List<DonationDto>>(donations);
        }

        public async Task<DonationDto> GetDonationByIdAsync(int donationId)
        {
            var donation = await _donationRepository.GetByIdAsync(donationId);
            if (donation == null)
                throw new KeyNotFoundException($"Donation with ID {donationId} not found.");

            return _mapper.Map<DonationDto>(donation);
        }

        public async Task<int> AddDonationAsync(CreateDonationDto createDonationDto)
        {
            var donation = _mapper.Map<Donation>(createDonationDto);
            var addedDonation = await _donationRepository.AddAsync(donation);
            return addedDonation.DonationId;
        }

        public async Task UpdateDonationAsync(int donationId, UpdateDonationDto updateDonationDto)
        {
            var donation = await _donationRepository.GetByIdAsync(donationId);
            if (donation == null)
                throw new KeyNotFoundException($"Donation with ID {donationId} not found.");

            _mapper.Map(updateDonationDto, donation);
            await _donationRepository.UpdateAsync(donation);
        }

        public async Task DeleteDonationAsync(int donationId)
        {
            var donation = await _donationRepository.GetByIdAsync(donationId);
            if (donation == null)
                throw new KeyNotFoundException($"Donation with ID {donationId} not found.");

            await _donationRepository.DeleteAsync(donation);
        }
    }
}
