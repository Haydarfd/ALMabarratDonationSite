using AutoMapper;
using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Core.Entities;

namespace AlMabarratDonationWebApp.Application.MappingProfiles
{
    public class SponsorshipRequestProfile : Profile
    {
        public SponsorshipRequestProfile()
        {
            CreateMap<SponsorshipRequest, SponsorshipRequestDto>().ReverseMap();
            CreateMap<CreateSponsorshipRequestDto, SponsorshipRequest>();
            CreateMap<UpdateSponsorshipRequestDto, SponsorshipRequest>();
        }
    }
}
