using AutoMapper;
using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Core.Entities;

namespace AlMabarratDonationWebApp.Application.MappingProfiles
{
    public class DonationProfile : Profile
    {
        public DonationProfile()
        {
            CreateMap<Donation, DonationDto>().ReverseMap();
            CreateMap<CreateDonationDto, Donation>();
            CreateMap<UpdateDonationDto, Donation>();
        }
    }
}
