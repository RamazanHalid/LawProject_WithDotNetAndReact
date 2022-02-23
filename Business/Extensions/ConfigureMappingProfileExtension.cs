using AutoMapper;
using Business.Abstract;
using Core.Utilities.IoC;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
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
                CreateMap<CaseStatus, CaseStatusGetDto>();
                CreateMap<CaseStatusAddDto, CaseStatus>();
                CreateMap<CaseStatusUpdateDto, CaseStatus>();

                //Licence
                CreateMap<LicenceAddDto, Licence>();

                CreateMap<ProcessType, ProcessTypeDto>()
                    .ReverseMap();
                CreateMap<TransactionActivitySubType, TransactionActivitySubTypeDto>()
                    .ReverseMap();
                CreateMap<CourtOffice, CourtOfficeDto>()
                    .ReverseMap();

            }
        }
    }
}
//.ForMember(x => x.TransactionAcitivityTypeId, y => y.MapFrom(i => i.TransactionActivityType.TransactionActivityTypeId))
//.ForMember(x => x.CourtOfficeTypeId, y => y.MapFrom(i => i.CourtOfficeType.CourtOfficeTypeId))
