using AutoMapper;
using Business.Abstract;
using Core.Utilities.IoC;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.CaseType;
using Entities.DTOs.LicenceUser;
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
                CreateMap<CaseStatus, CaseStatusGetDto>();
                CreateMap<CaseStatusAddDto, CaseStatus>();
                CreateMap<CaseStatusUpdateDto, CaseStatus>();

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

                //LicenceUser
                CreateMap<LicenceUser, LicenceUserGetDto>()
                    .ForMember(dest => dest.LicenceGetDto, x => x.MapFrom(src => src.Licence))
                    .ForMember(dest => dest.User, x => x.MapFrom(src => src.User));
                CreateMap<LicenceUserAddDto, LicenceUser>();
                ;
            }
        }
    }
}
//.ForMember(x => x.TransactionAcitivityTypeId, y => y.MapFrom(i => i.TransactionActivityType.TransactionActivityTypeId))
//.ForMember(x => x.CourtOfficeTypeId, y => y.MapFrom(i => i.CourtOfficeType.CourtOfficeTypeId))
