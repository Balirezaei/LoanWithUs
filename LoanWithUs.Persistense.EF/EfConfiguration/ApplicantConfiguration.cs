using LoanWithUs.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Persistense.EF.EfConfiguration
{
    public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.ToTable("Applicant");
            builder.HasKey(m => m.Id);
            builder.OwnsOne(  o => o.IdentityInformation).ToTable("IdentityInformation");
            builder.OwnsOne(m => m.EducationalInformation).ToTable("EducationalInformation");
            builder.OwnsOne(m => m.UserConfirmation).ToTable("UserConfirmation");
            builder.OwnsOne(m => m.AddressInformation).ToTable("AddressInformation");
            builder.OwnsOne(m => m.PersonalInformation).ToTable("PersonalInformation");
            builder.OwnsMany(m => m.UserDocuments).ToTable("UserDocument");
            builder.OwnsMany(m => m.UserLogins).ToTable("UserLogin");
        }
    }

    //public class AddressInformationConfiguration : IEntityTypeConfiguration<AddressInformation>
    //{
    //    public void Configure(EntityTypeBuilder<AddressInformation> builder)
    //    {
    //        builder.HasNoKey();
    //    }
    //}

}
