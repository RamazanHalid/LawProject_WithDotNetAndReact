using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();


            builder.RegisterType<ContactInformationManager>().As<IContactInformationService>().SingleInstance();
            builder.RegisterType<EfContactInformationDal>().As<IContactInformationDal>().SingleInstance();



            builder.RegisterType<SmsHistoryManager>().As<ISmsHistoryService>().SingleInstance();
            builder.RegisterType<EfSmsHistoryDal>().As<ISmsHistoryDal>().SingleInstance();


            builder.RegisterType<SmsOrderManager>().As<ISmsOrderService>().SingleInstance();
            builder.RegisterType<EfSmsOrderDal>().As<ISmsOrderDal>().SingleInstance();

            builder.RegisterType<NotificationManager>().As<INotificationService>().SingleInstance();
            builder.RegisterType<EfNotificationDal>().As<INotificationDal>().SingleInstance();

            builder.RegisterType<OperationClaimGroupManager>().As<IOperationClaimGroupService>().SingleInstance();
            builder.RegisterType<EfOperationClaimGroupDal>().As<IOperationClaimGroupDal>().SingleInstance();

            builder.RegisterType<LicenceManager>().As<ILicenceService>().SingleInstance();
            builder.RegisterType<EfLicenceDal>().As<ILicenceDal>().SingleInstance();

            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();

            builder.RegisterType<SmsTemplateManager>().As<ISmsTemplateService>().SingleInstance();
            builder.RegisterType<EfSmsTemplateDal>().As<ISmsTemplateDal>().SingleInstance();

            builder.RegisterType<CreditCardReminderManager>().As<ICreditCardReminderService>().SingleInstance();
            builder.RegisterType<EfCreditCardReminderDal>().As<ICreditCardReminderDal>().SingleInstance();

            builder.RegisterType<CourtOfficeTypeManager>().As<ICourtOfficeTypeService>().SingleInstance();
            builder.RegisterType<EfCourtOfficeTypeDal>().As<ICourtOfficeTypeDal>().SingleInstance();

            builder.RegisterType<EventTypeManager>().As<IEventTypeService>().SingleInstance();
            builder.RegisterType<EfEventTypeDal>().As<IEventTypeDal>().SingleInstance();

            builder.RegisterType<RoleTypeManager>().As<IRoleTypeService>().SingleInstance();
            builder.RegisterType<EfRoleTypeDal>().As<IRoleTypeDal>().SingleInstance();

            builder.RegisterType<EventtManager>().As<IEventtService>().SingleInstance();
            builder.RegisterType<EfEventtDal>().As<IEventtDal>().SingleInstance();

            builder.RegisterType<SmsAccountManager>().As<ISmsAccountService>().SingleInstance();
            builder.RegisterType<EfSmsAccountDal>().As<ISmsAccountDal>().SingleInstance();

            builder.RegisterType<CourtOfficeManager>().As<ICourtOfficeService>().SingleInstance();
            builder.RegisterType<EfCourtOfficeDal>().As<ICourtOfficeDal>().SingleInstance();

            builder.RegisterType<CountryManager>().As<ICountryService>().SingleInstance();
            builder.RegisterType<EfCountryDal>().As<ICountryDal>().SingleInstance();

            builder.RegisterType<LicenceUserManager>().As<ILicenceUserService>().SingleInstance();
            builder.RegisterType<EfLicenceUserDal>().As<ILicenceUserDal>().SingleInstance();

            builder.RegisterType<CaseStatusManager>().As<ICaseStatusService>().SingleInstance();
            builder.RegisterType<EfCaseStatusDal>().As<ICaseStatusDal>().SingleInstance();

            builder.RegisterType<ProcessTypeManager>().As<IProcessTypeService>().SingleInstance();
            builder.RegisterType<EfProcessTypeDal>().As<IProcessTypeDal>().SingleInstance();

            builder.RegisterType<CaseTypeManager>().As<ICaseTypeService>().SingleInstance();
            builder.RegisterType<EfCaseTypeDal>().As<ICaseTypeDal>().SingleInstance();

            builder.RegisterType<CaseeManager>().As<ICaseeService>().SingleInstance();
            builder.RegisterType<EfCaseeDal>().As<ICaseeDal>().SingleInstance();

            builder.RegisterType<TaskTypeManager>().As<ITaskTypeService>().SingleInstance();
            builder.RegisterType<EfTaskTypeDal>().As<ITaskTypeDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<TaskStatusManager>().As<ITaskStatusService>().SingleInstance();
            builder.RegisterType<EfTaskStatusDal>().As<ITaskStatusDal>().SingleInstance();

            builder.RegisterType<CasesDocumentManager>().As<ICasesDocumentService>().SingleInstance();
            builder.RegisterType<EfCasesDocumentDal>().As<ICasesDocumentDal>().SingleInstance();

            builder.RegisterType<TaskkManager>().As<ITaskkService>().SingleInstance();
            builder.RegisterType<EfTaskkDal>().As<ITaskkDal>().SingleInstance();

            builder.RegisterType<PersonTypeManager>().As<IPersonTypeService>().SingleInstance();
            builder.RegisterType<EfPersonTypeDal>().As<IPersonTypeDal>().SingleInstance();

            builder.RegisterType<TransactionActivityTypeManager>().As<ITransactionActivityTypeService>().SingleInstance();
            builder.RegisterType<EfTransactionActivityTypeDal>().As<ITransactionActivityTypeDal>().SingleInstance();

            builder.RegisterType<TransactionActivityManager>().As<ITransactionActivityService>().SingleInstance();
            builder.RegisterType<EfTransactionActivityDal>().As<ITransactionActivityDal>().SingleInstance();

            builder.RegisterType<TransactionActivitySubTypeManager>().As<ITransactionActivitySubTypeService>().SingleInstance();
            builder.RegisterType<EfTransactionActivitySubTypeDal>().As<ITransactionActivitySubTypeDal>().SingleInstance();

            builder.RegisterType<PaymentManager>().As<IPaymentService>().SingleInstance();

            builder.RegisterType<EmailManager>().As<IEmailService>();


            builder.RegisterType<PaymentHistoryManager>().As<IPaymentHistoryService>().SingleInstance();
            builder.RegisterType<EfPaymentHistoryDal>().As<IPaymentHistoryDal>().SingleInstance();




            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>().SingleInstance();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>().SingleInstance();

            builder.RegisterType<SmsManager>().As<ISmsService>().SingleInstance();

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
