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
            optionsBuilder.UseSqlServer(@"");
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Licence>(entity =>
            {
                entity.ToTable("Licences");

                entity.HasOne(i => i.User)
                .WithMany(i => (ICollection<Licence>)i.Licences);

                entity.HasMany(i => i.Casees)
               .WithOne(i => i.Licence)
               .OnDelete((DeleteBehavior)ReferentialAction.NoAction);

                entity.HasMany(i => i.Customers)
               .WithOne(i => i.Licence)
               .OnDelete((DeleteBehavior)ReferentialAction.NoAction);

                entity.HasMany(i => i.CustomerUsers)
               .WithOne(i => i.Licence)
               .OnDelete((DeleteBehavior)ReferentialAction.NoAction);

                entity.HasMany(i => i.Eventts)
             .WithOne(i => i.Licence)
             .OnDelete((DeleteBehavior)ReferentialAction.NoAction);


                entity.HasMany(i => i.Taskks)
             .WithOne(i => i.Licence)
             .OnDelete((DeleteBehavior)ReferentialAction.NoAction);
            });



            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.HasMany(i => (ICollection<Licence>)i.Licences)
                .WithOne(i => i.User)
                .OnDelete((DeleteBehavior)ReferentialAction.NoAction);
                entity.HasMany(i => (ICollection<Eventt>)i.Eventts)
               .WithOne(i => i.User)
                .OnDelete((DeleteBehavior)ReferentialAction.NoAction);
            });
            modelBuilder.Entity<TransactionActivity>(entity =>
            {
                entity.ToTable("TransactionActivities");

                //entity.HasOne(i => i.TransactionActivitySubType)
                //.WithMany(i => i.TransactionActivities)
                //.OnDelete((DeleteBehavior)ReferentialAction.NoAction);


                //entity.HasOne(i => i.UserWhoAdd)
                //.WithMany(i => (ICollection<TransactionActivity>)i.TransactionActivities)
                //.OnDelete((DeleteBehavior)ReferentialAction.NoAction);

                //entity.HasOne(i => i.WhoApproved)
                //.WithMany(i => (ICollection<TransactionActivity>)i.TransactionActivities2)
                //.OnDelete((DeleteBehavior)ReferentialAction.NoAction);
            });

            modelBuilder.Entity<Taskk>(entity =>
            {
                entity.ToTable("Taskks");

                //entity.HasOne(i => i.TaskType)
                //.WithMany(i => i.Taskks)
                //.OnDelete((DeleteBehavior)ReferentialAction.NoAction);

              //  entity.HasOne(i => i.User)
              //.WithMany(i => (ICollection<Taskk>)i.Taskks)
              //.OnDelete((DeleteBehavior)ReferentialAction.NoAction);



            });

            modelBuilder.Entity<TransactionActivitySubType>(entity =>
            {
                entity.ToTable("TransactionActivitySubTypes");

                //entity.HasOne(i => i.TransactionActivityType)
                //.WithMany(i => i.TransactionActivitySubTypes)
                //.OnDelete((DeleteBehavior)ReferentialAction.NoAction);
            });

            modelBuilder.Entity<LicenceUser>(entity =>
            {
                entity.ToTable("LicenceUsers");

                entity.HasOne(i => i.User2)
                .WithMany(i => (ICollection<LicenceUser>)i.LicenceUsers)
                .OnDelete((DeleteBehavior)ReferentialAction.NoAction);
            });
            modelBuilder.Entity<CaseType>(entity =>
            {
                entity.ToTable("CaseTypes");

                entity.HasMany(i => i.Casees)
                .WithOne(i => i.CaseType)
                .OnDelete((DeleteBehavior)ReferentialAction.NoAction);
            });
            modelBuilder.Entity<CourtOffice>(entity =>
            {
                entity.ToTable("CourtOffices");

                entity.HasMany(i => i.Casees)
                .WithOne(i => i.CourtOffice)
                .OnDelete((DeleteBehavior)ReferentialAction.NoAction);

                entity.HasOne(i => i.Licence)
                .WithMany(i => i.CourtOffices)
                .OnDelete((DeleteBehavior)ReferentialAction.NoAction);
            });
            modelBuilder.Entity<CourtOfficeType>(entity =>
            {
                entity.ToTable("CourtOfficeTypes");

                entity.HasMany(i => i.Casees)
                .WithOne(i => i.CourtOfficeType)
                .OnDelete((DeleteBehavior)ReferentialAction.NoAction);
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");

                //entity.HasOne(i => i.Casee)
                //.WithOne(i => i.Customer)
                //.OnDelete((DeleteBehavior)ReferentialAction.NoAction);
                entity.HasMany(i => i.Eventts)
                .WithOne(i => i.Customer)
                .OnDelete((DeleteBehavior)ReferentialAction.NoAction);
            });
        }
    }




}



