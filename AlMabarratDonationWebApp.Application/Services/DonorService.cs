using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Application.Interfaces.IServices;
using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Core.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlMabarratDonationWebApp.Application.Services
{
    public class DonorService : IDonorService
    {
        private readonly IDonorRepository _donorRepository;
        private readonly IMapper _mapper;

        public DonorService(IDonorRepository donorRepository, IMapper mapper)
        {
            _donorRepository = donorRepository;
            _mapper = mapper;
        }

        public async Task<int> AddDonorAsync(CreateDonorDto donorCreateDto)
        {
            var donor = _mapper.Map<Donor>(donorCreateDto);
            donor.CreationDate = DateTime.UtcNow; 

            await _donorRepository.AddAsync(donor);

            return donor.Id;
        }

        public async Task UpdateDonorAsync(int donorId, UpdateDonorDto donorUpdateDto)
        {
            var donor = await _donorRepository.GetByIdAsync(donorId);
            if (donor == null)
                throw new KeyNotFoundException($"Donor with Id {donorId} not found.");

            _mapper.Map(donorUpdateDto, donor);
            await _donorRepository.UpdateAsync(donor); // Add this line
        }

        public async Task<List<DonationDto>> GetDonationsByDonorIdAsync(int donorId)
        {
            var donations = _donorRepository.GetDonationHistory(donorId);
            var donationDtos = _mapper.Map<List<DonationDto>>(donations);
            return donationDtos;
        }

        public async Task<List<OrphanDto>> GetSponsoredOrphansByDonorIdAsync(int donorId)
        {
            var orphans = _donorRepository.GetSponsoredOrphansByDonorId(donorId);
            var orphanDtos = _mapper.Map<List<OrphanDto>>(orphans);
            return orphanDtos;
        }
        public async Task<List<DonationDto>> GetDonationsByDonationTypeAsync(int donorId, int donationTypeId)
        {
            var donations = _donorRepository
                .GetDonationHistory(donorId)
                .Where(d => d.DonationTypeId == donationTypeId)
                .ToList();

            var donationDtos = _mapper.Map<List<DonationDto>>(donations);
            return donationDtos;
        }
        public async Task<List<DonorDto>> GetAllDonorsAsync()
        {
            var donors = await _donorRepository.GetAllAsync();
            return _mapper.Map<List<DonorDto>>(donors);
        }

        public async Task<DonorDto?> GetDonorByIdAsync(int donorId)
        {
            var donor = await _donorRepository.GetByIdAsync(donorId);
            return donor != null ? _mapper.Map<DonorDto>(donor) : null;
        }

        public async Task<UpdateDonorDto?> GetDonorForUpdateAsync(int donorId)
        {
            var donor = await _donorRepository.GetByIdAsync(donorId);
            return donor != null ? _mapper.Map<UpdateDonorDto>(donor) : null;
        }

        public async Task DeleteDonorAsync(int donorId, string reason)
        {
            var donor = await _donorRepository.GetByIdAsync(donorId);
            if (donor == null)
                throw new KeyNotFoundException($"Donor with Id {donorId} not found.");

            donor.IsDeleted = true;
            donor.DeletionDate = DateTime.UtcNow;
            donor.DeletionReason = reason;

            await _donorRepository.UpdateAsync(donor); 
        }

    }
}
