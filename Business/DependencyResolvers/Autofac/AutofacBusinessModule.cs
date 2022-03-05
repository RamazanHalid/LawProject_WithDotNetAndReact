using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<LicenceManager>().As<ILicenceService>();
            builder.RegisterType<EfLicenceDal>().As<ILicenceDal>();

            builder.RegisterType<CityManager>().As<ICityService>();
            builder.RegisterType<EfCityDal>().As<ICityDal>();

            builder.RegisterType<CourtOfficeTypeManager>().As<ICourtOfficeTypeService>();
            builder.RegisterType<EfCourtOfficeTypeDal>().As<ICourtOfficeTypeDal>();

            builder.RegisterType<CountryManager>().As<ICountryService>();
            builder.RegisterType<EfCountryDal>().As<ICountryDal>();

            builder.RegisterType<LicenceUserManager>().As<ILicenceUserService>();
            builder.RegisterType<EfLicenceUserDal>().As<ILicenceUserDal>();

            builder.RegisterType<CaseStatusManager>().As<ICaseStatusService>();
            builder.RegisterType<EfCaseStatusDal>().As<ICaseStatusDal>();

            builder.RegisterType<CaseTypeManager>().As<ICaseTypeService>();
            builder.RegisterType<EfCaseTypeDal>().As<ICaseTypeDal>();

            builder.RegisterType<TaskTypeManager>().As<ITaskTypeService>();
            builder.RegisterType<EfTaskTypeDal>().As<ITaskTypeDal>();

            builder.RegisterType<TransactionActivityTypeManager>().As<ITransactionActivityTypeService>();
            builder.RegisterType<EfTransactionActivityTypeDal>().As<ITransactionActivityTypeDal>();

            builder.RegisterType<TransactionActivitySubTypeManager>().As<ITransactionActivitySubTypeService>();
            builder.RegisterType<EfTransactionActivitySubTypeDal>().As<ITransactionActivitySubTypeDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();

            builder.RegisterType<SmsManager>().As<ISmsService>();

            builder.RegisterType<CurrentUserManager>().As<ICurrentUserService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
