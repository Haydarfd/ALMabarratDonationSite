using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Application.Interfaces.IServices;
using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Core.Repositories;
using AutoMapper;

namespace AlMabarratDonationWebApp.Application.Services
{
    public class SponsorshipRequestService : ISponsorshipRequestService
    {
        private readonly ISponsorshipRequestRepository _repository;
        private readonly IMapper _mapper;

        // Constructor with Dependency Injection
        public SponsorshipRequestService(ISponsorshipRequestRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task CreateSponsorshipRequestAsync(CreateSponsorshipRequestDto dto, string userId)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrEmpty(userId)) throw new ArgumentException("User ID is required.", nameof(userId));

            var sponsorshipRequest = new SponsorshipRequest
            {
                AgeGroup = dto.AgeGroup,
                Gender = dto.Gender,
                Amount = dto.Amount,
                PaymentType = dto.PaymentType,
                SponsorshipType = dto.SponsorshipType,
                AppUserId = userId,             // FK to AppUser
                RequestedOn = DateTime.UtcNow,  // Set current UTC time
                IsHandled = false               // Default to unhandled
            };

            await _repository.AddAsync(sponsorshipRequest); // Now saves a complete object
        }


        public async Task<List<SponsorshipRequestDto>> GetAllAsync()
        {
            var sponsorshipRequests = await _repository.GetAllWithDonorAsync();

            // Map manually to DTO
            var sponsorshipRequestDtos = sponsorshipRequests.Select(sr => new SponsorshipRequestDto
            {
                SponsorshipId = sr.Id,
                AgeGroup = sr.AgeGroup,
                Gender = sr.Gender,
                Amount = sr.Amount,
                PaymentType = sr.PaymentType,
                SponsorshipType = sr.SponsorshipType,
                DonorEmail = sr.AppUser.Email,    // Email is now loaded from AppUser
                DonorName = sr.AppUser.FullName   // Username is now loaded from AppUser
            }).ToList();

            return sponsorshipRequestDtos;
        }

        public Task<List<SponsorshipRequestDto>> GetAllWithDonorEmailAsync()
        {
            throw new NotImplementedException();
        }
    }
}