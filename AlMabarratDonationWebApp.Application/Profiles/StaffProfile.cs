using AlMabarratDonationWebApp.Application.DTO;
using AlMabarratDonationWebApp.Core.Entities;
using AutoMapper;

namespace AlMabarratDonationWebApp.Service.MappingProfiles
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
                // Map Staff → StaffDto
                CreateMap<Staff, StaffDto>()
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName))
                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber))
                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.User.Address))
                    .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.User.City))
                    .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.User.PostalCode))
                    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.User.Country))
                    .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => src.User.UserType))
                    .ForMember(dest => dest.JoinDate,
                        opt => opt.MapFrom(src => src.JoinDate.ToDateTime(new TimeOnly(0, 0))));


            CreateMap<Staff, UpdateStaffDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.User.Address))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.User.City))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.User.PostalCode))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.User.Country))
                .ForMember(dest => dest.StaffID, opt => opt.MapFrom(src => src.StaffID))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.RequiresPasswordChange, opt => opt.MapFrom(src => src.RequiresPasswordChange))
                .ForMember(dest => dest.JoinDate, opt => opt.MapFrom(src => src.JoinDate.ToDateTime(TimeOnly.MinValue)));

            // UpdateStaffDto → Staff
            CreateMap<UpdateStaffDto, Staff>()
                .ForMember(dest => dest.JoinDate,
                    opt => opt.MapFrom(src => DateOnly.FromDateTime(src.JoinDate)));
        }
    }
}