using AutoMapper;
using AlMabarratDonationWebApp.Core.Entities;
using AlMabarratDonationWebApp.Application.DTO;

namespace AlMabarratDonationWebApp.Application.Profiles
{
    public class DonorProfile : Profile
    {
        public DonorProfile()
        {
            CreateMap<Donor, DonorDto>()
                .ForMember(dest => dest.AppUserName, opt => opt.MapFrom(src => src.AppUser.UserName));

            CreateMap<CreateDonorDto, Donor>();
            CreateMap<UpdateDonorDto, Donor>();
            CreateMap<Donor, UpdateDonorDto>().ReverseMap(); 

        }
    }
}
