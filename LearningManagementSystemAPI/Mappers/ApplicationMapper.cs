using AutoMapper;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using LearningManagementSystemAPI.Helpers;

namespace LearningManagementSystemAPI.Mappers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<Account, AccountDTO>();
            CreateMap<UpdateAccountDTO, Account>();
            CreateMap<CreateAccountDTO, Account>()
                .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => "DefaultAvatar.png"))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => MD5Encryption.CalculateMD5(src.Password)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => true));
            CreateMap<Class, ClassDTO>();
            CreateMap<CreateClassDTO, Class>();
            CreateMap<Department, DepartmentDTO>();
            CreateMap<CreateDepartmentDTO, Department>();
            CreateMap<Permission, PermissionDTO>();
            CreateMap<CreatePermissionDTO, Permission>();
            CreateMap<PermissionRole, PermissionRoleDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Permission.PermissionId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Permission.Name));
            CreateMap<Role, RoleDTO>()
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.PermissionRoles));
            CreateMap<CreateRoleDTO, Role>();
            CreateMap<PrivateFiles, PrivateFilesDTO>();
            CreateMap<CreatePrivateFilesDTO, PrivateFiles>();
            CreateMap<UserUpdateAccountDTO, Account>();
        }
    }
}
