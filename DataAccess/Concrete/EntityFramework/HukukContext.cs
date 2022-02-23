using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
        public DbSet<CustomerUser> CustomerUsers { get; set; }
        public DbSet<CustomerUserRelation> CustomerUserRelations { get; set; }
        public DbSet<LicenceUser> LicenceUsers { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<ProcessType> ProcessTypes { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<TransactionActivitySubType> TransactionAcitivitySubTypes { get; set; }
        public DbSet<TransactionActivityType> TransactionActivityTypes { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Licence>(entity =>
            {
                entity.ToTable("Licences");

                entity.HasOne(i => i.City)
                .WithMany(i => i.Licences)
                .HasForeignKey(i => i.CityId)
                .HasConstraintName("licenceCityIdFK");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Countries");
                entity.HasMany(i => i.Cities)
                .WithOne(i => i.Country)
                .HasForeignKey(i => i.CountryId)
                .HasConstraintName("cityCountryIdFK");
            });



        }

    }
}
