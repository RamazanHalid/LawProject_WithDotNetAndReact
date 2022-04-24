using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace DataAccess.Concrete.EntityFramework
{
    public class HukukContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=178.157.15.114;Database=HUKUK2;User Id = sa;Password=Terra2010*");
        }
        public DbSet<Licence> Licences { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CaseStatus> CaseStatuses { get; set; }
        public DbSet<CaseType> CaseTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CourtOffice> CourtOffices { get; set; }
        public DbSet<CourtOfficeType> CourtOfficeTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LicenceUser> LicenceUsers { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<ProcessType> ProcessTypes { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<TransactionActivity> TransactionActivities { get; set; }
        public DbSet<TransactionActivitySubType> TransactionAcitivitySubTypes { get; set; }
        public DbSet<TransactionActivityType> TransactionActivityTypes { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaimCategory> OperationClaimCategories { get; set; }
        public DbSet<AccountActivity> AccountActivities { get; set; }
        public DbSet<AccountActivityStatus> AccountActivityStatuses { get; set; }
        public DbSet<AccountActivityType> AccountActivityTypes { get; set; }
        public DbSet<Casee> Casees { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<CustomerUser> CustomerUsers { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Eventt> Eventts { get; set; }
        public DbSet<RoleType> RoleTypes { get; set; }
        public DbSet<SmsTemplate> SmsTemplates { get; set; }
        public DbSet<Taskk> Taskks { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }
        public DbSet<SmsAccount> SmsAccounts { get; set; }
        public DbSet<OperationClaimGroup> OperationClaimGroups { get; set; }
        public DbSet<PaymentHistory> PaymentHistories { get; set; }
        public DbSet<CreditCardReminder> CreditCardReminders { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<CasesDocument> CasesDocuments { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
        public DbSet<SmsOrder> SmsOrders { get; set; }
        public DbSet<SmsHistory> SmsHistories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SmsHistory>()
         .HasOne(t => t.Licence)
         .WithMany()
         .OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<CasesDocument>()
         .HasOne(t => t.Creator)
         .WithMany()
         .OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<CasesDocument>()
         .HasOne(t => t.Casee)
         .WithMany()
         .OnDelete((DeleteBehavior)ReferentialAction.NoAction);




            modelBuilder.Entity<Notification>()
         .HasOne(t => t.Licence)
         .WithMany()
         .OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<Notification>()
         .HasOne(t => t.User)
         .WithMany()
         .OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<PaymentHistory>()
           .HasOne(t => t.Licence)
           .WithMany();

            modelBuilder.Entity<PaymentHistory>()
           .HasOne(t => t.Licence)
           .WithMany()
           .OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<OperationClaimGroup>()
               .HasMany(t => t.OperationClaims)
               .WithOne()
               .OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<Licence>()
         .HasOne(t => t.City)
         .WithMany()
         .OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<Licence>()
             .HasOne(t => t.PersonType)
             .WithMany()
             .OnDelete((DeleteBehavior)ReferentialAction.NoAction);



            modelBuilder.Entity<Licence>()
             .HasOne(t => t.User)
             .WithMany()
             .OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<City>()
             .HasOne(t => t.Country)
             .WithMany()
             .OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<CaseStatus>()
             .HasOne(t => t.CourtOfficeType)
             .WithMany()
             .OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<CaseStatus>()
                       .HasOne(t => t.Licence)
                       .WithMany()
                       .OnDelete((DeleteBehavior)ReferentialAction.NoAction);



            modelBuilder.Entity<CaseType>()
                       .HasOne(t => t.Licence)
                       .WithMany()
                       .OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<CaseType>()
                     .HasOne(t => t.CourtOfficeType)
                     .WithMany()
                     .OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<CourtOffice>()
               .HasOne(t => t.Licence)
               .WithMany()
               .OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<CourtOffice>()
               .HasOne(t => t.City)
               .WithMany()
               .OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<CourtOffice>()
               .HasOne(t => t.CourtOfficeType)
               .WithMany()
               .OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<Customer>()
               .HasOne(t => t.City)
               .WithMany()
               .OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<Customer>()
              .HasOne(t => t.Licence)
              .WithMany()
              .OnDelete((DeleteBehavior)ReferentialAction.NoAction);



            modelBuilder.Entity<ProcessType>()
              .HasOne(t => t.Licence)
              .WithMany()
              .OnDelete((DeleteBehavior)ReferentialAction.NoAction);



            modelBuilder.Entity<TaskType>()
              .HasOne(t => t.Licence)
              .WithMany()
              .OnDelete((DeleteBehavior)ReferentialAction.NoAction);



            modelBuilder.Entity<TransactionActivity>()
          .HasOne(t => t.Licence)
          .WithMany()
          .OnDelete((DeleteBehavior)ReferentialAction.NoAction);



            modelBuilder.Entity<TransactionActivity>()
          .HasOne(t => t.TransactionActivitySubType)
          .WithMany()
          .OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<TransactionActivity>()
          .HasOne(t => t.UserWhoAdd)
          .WithMany()
          .OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<TransactionActivity>()
       .HasOne(t => t.WhoApproved)
       .WithMany()
       .OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<TransactionActivitySubType>()
       .HasOne(t => t.Licence)
       .WithMany()
       .OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<TransactionActivitySubType>()
.HasOne(t => t.TransactionActivityType)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<AccountActivity>()
.HasOne(t => t.Licence)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<AccountActivity>()
.HasOne(t => t.OrderType)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<AccountActivity>()
.HasOne(t => t.AccountActivityStatus)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<AccountActivity>()
.HasOne(t => t.AccountActivityType)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);



            modelBuilder.Entity<Casee>()
.HasOne(t => t.CaseStatus)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<Casee>()
.HasOne(t => t.CaseType)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<Casee>()
.HasOne(t => t.CourtOffice)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<Casee>()
.HasOne(t => t.CourtOfficeType)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<Casee>()
.HasOne(t => t.Customer)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);
            modelBuilder.Entity<Casee>()
 .HasOne(t => t.Licence)
 .WithMany()
 .OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<Casee>()
.HasOne(t => t.RoleType)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<CustomerUser>()
.HasOne(t => t.Licence)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<CustomerUser>()
.HasOne(t => t.City)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<CustomerUser>()
.HasOne(t => t.PersonType)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<Eventt>()
.HasOne(t => t.Casee)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<Eventt>()
.HasOne(t => t.Creator)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<Eventt>()
.HasOne(t => t.Customer)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<Eventt>()
.HasOne(t => t.EventType)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<Eventt>()
.HasOne(t => t.Licence)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<Eventt>()
.HasOne(t => t.User)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);
            modelBuilder.Entity<RoleType>()
.HasOne(t => t.CourtOfficeType)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);
            modelBuilder.Entity<SmsTemplate>()
.HasOne(t => t.Licence)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);
            modelBuilder.Entity<Taskk>()
.HasOne(t => t.Licence)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<Taskk>()
.HasOne(t => t.Casee)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<Taskk>()
.HasOne(t => t.Creator)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<Taskk>()
.HasOne(t => t.Customer)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<Taskk>()
.HasOne(t => t.TaskStatus)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<Taskk>()
.HasOne(t => t.TaskType)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);

            modelBuilder.Entity<Taskk>()
.HasOne(t => t.User)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);


            modelBuilder.Entity<SmsAccount>()
.HasOne(t => t.Licence)
.WithMany()
.OnDelete((DeleteBehavior)ReferentialAction.NoAction);



        }
    }




}



