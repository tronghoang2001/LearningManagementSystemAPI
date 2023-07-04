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
            CreateMap<RenamePrivateFilesDTO, PrivateFiles>();
            CreateMap<UserUpdateAccountDTO, Account>();
            CreateMap<Subject, SubjectDTO>();
            CreateMap<CreateSubjectDTO, Subject>();
            CreateMap<ApproveDTO, Subject>();
            CreateMap<ApproveDTO, Lesson>();
            CreateMap<ApproveDTO, Resources>();
            CreateMap<ApproveDTO, Exam>();
            CreateMap<Subject, SubjectDetailsDTO>()
                .ForMember(dest => dest.Topic_list, opt => opt.MapFrom(src => src.Topics))
                .ForMember(dest => dest.subjectOverview, opt => opt.MapFrom(src => src.SubjectAssignments));
            CreateMap<SubjectAssignment, SubjectOverviewDTO>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Class.Department.Name))
                .ForMember(dest => dest.ClassCode, opt => opt.MapFrom(src => src.Class.Code))
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class.Name));
            CreateMap<CreateTopicDTO, Topic>();
            CreateMap<UpdateTopicDTO, Topic>();
            CreateMap<Topic, TopicDTO>()
                .ForMember(dest => dest.Lesson, opt => opt.MapFrom(src => src.Lessons));
            CreateMap<CreateLessonDTO, Lesson>();
            CreateMap<Lesson, LessonDTO>()
                .ForMember(dest => dest.Resources_list, opt => opt.MapFrom(src => src.Resources));
            CreateMap<CreateResourcesDTO, Resources>();
            CreateMap<Resources, ResourcesDTO>();
            CreateMap<Exam, ExamDTO>()
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name))
                .ForMember(dest => dest.Lecturers, opt => opt.MapFrom(src => src.Subject.Sender))
                .ForMember(dest => dest.Question_list, opt => opt.MapFrom(src => src.ExamDetails))
                .ForMember(dest => dest.Answer_list, opt => opt.MapFrom(src => src.ExamDetails));
            CreateMap<ExamDetails, ExamDetailsDTO>()
                .ForMember(dest => dest.Question, opt => opt.MapFrom(src => src.QuestionBank.Question))
                .ForMember(dest => dest.A, opt => opt.MapFrom(src => src.QuestionBank.A))
                .ForMember(dest => dest.B, opt => opt.MapFrom(src => src.QuestionBank.B))
                .ForMember(dest => dest.C, opt => opt.MapFrom(src => src.QuestionBank.C))
                .ForMember(dest => dest.D, opt => opt.MapFrom(src => src.QuestionBank.D));
            CreateMap<ExamDetails, ExamAnswersDTO>()
                .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.QuestionBank.Answer));
            CreateMap<CreateSupportDTO, Support>();
            CreateMap<CreateNotificationDTO, Notification>()
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.IsRead, opt => opt.MapFrom(src => false));
            CreateMap<Notification, NotificationDTO>()
                .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.Account.Name));
            CreateMap<CreateSubjectAssignmentDTO, SubjectAssignment>();
            CreateMap<CreateQuestionDTO, Question>()
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.IsAnswer, opt => opt.MapFrom(src => false));
            CreateMap<CreateAnswerDTO, Answer>()
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<Question, QuestionDTO>()
                .ForMember(dest => dest.Answer_list, opt => opt.MapFrom(src => src.QuestionDetails));
            CreateMap<QuestionDetails, AnswerDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Account.Name))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.Answer.CreateDate))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Answer.Content));
        }
    }
}
