using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Core.Entities;
using AutoMapper;

namespace AlMabarratDonationWebApp.Application.Mappings
{
    public class CampaignProfile : Profile
    {
        public CampaignProfile()
        {
            CreateMap<Campaign, CampaignDto>();
            CreateMap<CreateCampaignDto, Campaign>()
                .ForMember(dest => dest.CampaignID, opt => opt.Ignore())
                .ForMember(dest => dest.CurrentAmount, opt => opt.MapFrom(src => 0));
            CreateMap<UpdateCampaignDto, Campaign>()
                .ForMember(dest => dest.CampaignID, opt => opt.Ignore());
        }
    }
}
