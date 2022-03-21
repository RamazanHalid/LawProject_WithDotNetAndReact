using AutoMapper;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs.CaseeDtos;
using Entities.DTOs.CaseStatusDtos;
using Entities.DTOs.CaseTypeDtos;
using Entities.DTOs.CourtOfficeDtos;
using Entities.DTOs.CourtOfficeTypeDtos;
using Entities.DTOs.CustomerDtos;
using Entities.DTOs.EventtDtos;
using Entities.DTOs.EventTypeDtos;
using Entities.DTOs.LicenceDtos;
using Entities.DTOs.LicenceUserDtos;
using Entities.DTOs.ProcessTypeDtos;
using Entities.DTOs.SmsAccountDtos;
using Entities.DTOs.TaskkDtos;
using Entities.DTOs.TaskStatusDtos;
using Entities.DTOs.TaskTypeDtos;
using Entities.DTOs.TransactionActivityDtos;
using Entities.DTOs.TransactionActivitySubTypeDtos;
using Entities.DTOs.UserDtos;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public static class ConfigureMappingProfileExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection serviceCollection)
        {
            var mappingConfig = new MapperConfiguration(i => i.AddProfile(
                new AutoMapperMappingProfile()));
            IMapper mapper = mappingConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
            return serviceCollection;
        }
        public class AutoMapperMappingProfile : Profile
        {
            public AutoMapperMappingProfile()
            {
                //CaseStatus
                CreateMap<CaseStatus, CaseStatusGetDto>()
                    .ForMember(dest => dest.CourtOfficeTypeGetDto, x => x.MapFrom(src => src.CourtOfficeType));
                CreateMap<CaseStatusAddDto, CaseStatus>();
                CreateMap<CaseStatusUpdateDto, CaseStatus>();

                //Users
                CreateMap<User, UserForAddAnOtherLicenceInfo>();

                //TaskType
                CreateMap<CaseType, CaseTypeGetDto>();
                CreateMap<CaseStatusAddDto, CaseType>();
                CreateMap<CaseTypeUpdateDto, CaseType>();
                //Eventt
                CreateMap<Eventt, EventtGetDto>();
                CreateMap<EventtAddDto, Eventt>();
                CreateMap<EventtUpdateDto, Eventt>();

                //Casee
                CreateMap<Casee, CaseeGetDto>();
                CreateMap<CaseeAddDto, Casee>();
                CreateMap<CaseeUpdateDto, Casee>();

                //Licence
                CreateMap<LicenceAddDto, Licence>();
                CreateMap<Licence, LicenceAfterLoginDto>();
                CreateMap<LicenceUpdateDto, Licence>();
                CreateMap<Licence, LicenceGetDto>();

                //TaskType
                CreateMap<TaskTypeUpdateDto, TaskType>();
                CreateMap<TaskTypeAddDto, TaskType>();
                CreateMap<TaskType, TaskTypeGetDto>();

                //TaskStatus
                CreateMap<TaskStatusUpdateDto, TaskStatus>();
                CreateMap<TaskStatusAddDto, TaskStatus>();
                CreateMap<TaskStatus, TaskStatusGetDto>();
                //Taskk
                CreateMap<TaskkUpdateDto, Taskk>();
                CreateMap<TaskkAddDto, Taskk>();
                CreateMap<Taskk, TaskkGetDto>();

                //ProcessType
                CreateMap<ProcessTypeUpdateDto, ProcessType>();
                CreateMap<ProcessTypeAddDto, ProcessType>();
                CreateMap<ProcessType, ProcessTypeGetDto>();

                //ProcessType
                CreateMap<EventTypeUpdateDto, EventType>();
                CreateMap<EventTypeAddDto, EventType>();
                CreateMap<EventType, EventTypeGetDto>();


                //CaseType
                CreateMap<CaseTypeUpdateDto, CaseType>();
                CreateMap<CaseTypeAddDto, CaseType>();
                CreateMap<CaseType, CaseTypeGetDto>()
                    .ForMember(dst => dst.CourtOfficeTypeGetDto, x => x.MapFrom(src => src.CourtOfficeType));

                //LicenceUser
                CreateMap<LicenceUserAddDto, LicenceUser>();
                CreateMap<LicenceUser, LicenceUserGetDto>()
                    .ForMember(dest => dest.LicenceGetDto, x => x.MapFrom(src => src.Licence))
                    .ForMember(dest => dest.User, x => x.MapFrom(src => src.User2));

                //CourtOffice
                CreateMap<CourtOfficeUpdateDto, CourtOffice>();
                CreateMap<CourtOfficeAddDto, CourtOffice>();
                CreateMap<CourtOffice, CourtOfficeGetDto>()
                    .ForMember(dst => dst.CourtOfficeTypeGetDto, x => x.MapFrom(src => src.CourtOfficeType))
                    .ForMember(dst => dst.City, x => x.MapFrom(src => src.City));

                //CourtOfficeType
                CreateMap<CourtOfficeTypeUpdateDto, CourtOfficeType>();
                CreateMap<CourtOfficeTypeAddDto, CourtOfficeType>();
                CreateMap<CourtOfficeType, CourtOfficeTypeGetDto>();

                //Customer
                CreateMap<CustomerUpdateDto, Customer>();
                CreateMap<CustomerAddDto, Customer>();
                CreateMap<Customer, CustomerGetDto>();

                //SmsAccount
                CreateMap<SmsAccountAddDto, SmsAccount>();
                CreateMap<SmsAccount, SmsAccountGetDto>();

                //TransactionActivitySubType
                CreateMap<TransactionActivitySubTypeUpdateDto, TransactionActivitySubType>();
                CreateMap<TransactionActivitySubTypeAddDto, TransactionActivitySubType>();
                CreateMap<TransactionActivitySubType, TransactionActivitySubTypeGetDto>()
                    .ForPath(src => src.TransactionAcitivitySubTypeName, x => x.MapFrom(dst => dst.TransactionActivitySubTypeName))
                    .ForPath(src => src.TransactionAcitivitySubTypeId, x => x.MapFrom(dst => dst.TransactionActivitySubTypeId))
                    .ForPath(src => src.IsActive, x => x.MapFrom(dst => dst.IsActive))
                    .ForPath(src => src.TransactionActivityType, x => x.MapFrom(dst => dst.TransactionActivityType));

                //TransactionActivity
                CreateMap<TransactionActivityUpdateDto, TransactionActivity>();
                CreateMap<TransactionActivityAddDto, TransactionActivity>();
                CreateMap<TransactionActivity, TransactionActivityGetDto>()
                    .ForMember(src => src.TransactionActivitySubTypeGetDto, x => x.MapFrom(dst => dst.TransactionActivitySubType))
                    .ForPath(src => src.TransactionActivitySubTypeGetDto.TransactionAcitivitySubTypeName, x => x.MapFrom(dst => dst.TransactionActivitySubType.TransactionActivitySubTypeName))
                    .ForPath(src => src.TransactionActivitySubTypeGetDto.TransactionAcitivitySubTypeId, x => x.MapFrom(dst => dst.TransactionActivitySubType.TransactionActivitySubTypeId))
                    .ForPath(src => src.TransactionActivitySubTypeGetDto.IsActive, x => x.MapFrom(dst => dst.TransactionActivitySubType.IsActive))
                    .ForPath(src => src.TransactionActivitySubTypeGetDto.TransactionActivityType, x => x.MapFrom(dst => dst.TransactionActivitySubType.TransactionActivityType));
            }
        }
    }
}
