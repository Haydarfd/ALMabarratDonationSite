using AutoMapper;
using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Core.Entities;

namespace AlMabarratDonationWebApp.Application.MappingProfiles
{
    public class OrphanProfile : Profile
    {
        public OrphanProfile()
        {
            CreateMap<Orphan, OrphanDto>();

            CreateMap<CreateOrphanDto, Orphan>();

            CreateMap<UpdateOrphanDto, Orphan>();

            CreateMap<Orphan, OrphanDto>()
            .ForMember(dest => dest.SponsorshipType, opt => opt.MapFrom(src => src.SponsorshipType));

        }
    }
}
