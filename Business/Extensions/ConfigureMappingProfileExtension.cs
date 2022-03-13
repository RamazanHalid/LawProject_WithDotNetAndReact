using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.IoC;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.CaseType;
using Entities.DTOs.CourtOffice;
using Entities.DTOs.CourtOfficeType;
using Entities.DTOs.LicenceUser;
using Entities.DTOs.ProcessType;
using Entities.DTOs.TransactionActivitySubType;
using Entities.DTOs.User;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

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
                    .ForMember(dest => dest.CourtOfficeTypeGetDto, x => x.MapFrom(src => src.CourtOfficeType))
                    ;
                CreateMap<CaseStatusAddDto, CaseStatus>();
                CreateMap<CaseStatusUpdateDto, CaseStatus>();

                //Users
                CreateMap<User, UserForAddAnOtherLicenceInfo>();

                //TaskType
                CreateMap<CaseType, CaseTypeGetDto>();
                CreateMap<CaseStatusAddDto, CaseType>();
                CreateMap<CaseTypeUpdateDto, CaseType>();

                //Licence
                CreateMap<LicenceAddDto, Licence>();
                CreateMap<Licence, LicenceAfterLoginDto>();
                CreateMap<LicenceUpdateDto, Licence>();
                CreateMap<Licence, LicenceGetDto>();

                //TaskType
                CreateMap<TaskTypeUpdateDto, TaskType>();
                CreateMap<TaskTypeAddDto, TaskType>();
                CreateMap<TaskType, TaskTypeGetDto>();

                //ProcessType
                CreateMap<ProcessTypeUpdateDto, ProcessType>();
                CreateMap<ProcessTypeAddDto, ProcessType>();
                CreateMap<ProcessType, ProcessTypeGetDto>();


                //CaseType
                CreateMap<CaseTypeUpdateDto, CaseType>();
                CreateMap<CaseTypeAddDto, CaseType>();
                CreateMap<CaseType, CaseTypeGetDto>()
                    .ForMember(dst => dst.CourtOfficeTypeGetDto, x => x.MapFrom(src => src.CourtOfficeType));

                //LicenceUser
                CreateMap<LicenceUser, LicenceUserGetDto>()
                    .ForMember(dest => dest.LicenceGetDto, x => x.MapFrom(src => src.Licence))
                    .ForMember(dest => dest.User, x => x.MapFrom(src => src.User2));
                CreateMap<LicenceUserAddDto, LicenceUser>();

                //CourtOffice
                CreateMap<CourtOfficeUpdateDto, CourtOffice>();
                CreateMap<CourtOfficeAddDto, CourtOffice>();
                CreateMap<CourtOffice, CourtOfficeGetDto>().ForMember(dst => dst.CourtOfficeTypeGetDto, x => x.MapFrom(src => src.CourtOfficeType))
                    .ForMember(dst => dst.City, x => x.MapFrom(src => src.City));

                //CourtOfficeType
                CreateMap<CourtOfficeTypeUpdateDto, CourtOfficeType>();
                CreateMap<CourtOfficeTypeAddDto, CourtOfficeType>();
                CreateMap<CourtOfficeType, CourtOfficeTypeGetDto>();

                //TransactionActivitySubType
                CreateMap<TransactionActivitySubTypeUpdateDto, TransactionActivitySubType>();
                CreateMap<TransactionActivitySubTypeAddDto, TransactionActivitySubType>();
                CreateMap<TransactionActivitySubType, TransactionActivitySubTypeGetDto>();


            }
        }
    }
}
//.ForMember(x => x.TransactionAcitivityTypeId, y => y.MapFrom(i => i.TransactionActivityType.TransactionActivityTypeId))
//.ForMember(x => x.CourtOfficeTypeId, y => y.MapFrom(i => i.CourtOfficeType.CourtOfficeTypeId))
