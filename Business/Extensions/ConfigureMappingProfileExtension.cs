using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public static class ConfigureMappingProfileExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection serviceCollection)
        {
            var mappingConfig = new MapperConfiguration(i => i.AddProfile(new AutoMapperMappingProfile()));
            IMapper mapper = mappingConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
            return serviceCollection;
        }
        public class AutoMapperMappingProfile : Profile
        {
            public AutoMapperMappingProfile()
            {
                CreateMap<CaseStatus, CaseStatusDto>()
                    .ReverseMap();
                CreateMap<CaseType, CaseTypeDto>()
                    .ReverseMap();
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
