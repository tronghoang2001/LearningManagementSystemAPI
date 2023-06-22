using AutoMapper;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Mappers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<CreateAccountDTO, Account>()
                .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => "DefaultAvatar.png"))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => true));
        }
    }
}
