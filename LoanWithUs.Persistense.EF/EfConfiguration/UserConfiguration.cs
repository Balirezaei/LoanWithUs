using LoanWithUs.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWithUs.Persistense.EF.EfConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.RegisterationDate).HasColumnName("RegisterationDate");
            //builder.Ignore(m => m.IdentityInformation);

            builder.OwnsOne(m => m.EducationalInformation).ToTable("EducationalInformation");
            builder.OwnsOne(m => m.UserConfirmation).ToTable("UserConfirmation");
            builder.OwnsOne(m => m.AddressInformation).ToTable("AddressInformation");




            //builder.OwnsOne(m => m.AddressInformation,
            //sa =>
            //{

            //    //sa.HasOne(c => c.Province).WithMany().HasForeignKey(a => a.CountryCode);
            //    ////sa.WithOwner().HasForeignKey().
            //    sa.HasOne(p => p.Province)
            //    .WithMany()
            //    .HasForeignKey(p => p.ProvinceId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //    //sa.HasOne(p => p.City)
            //    //   .WithMany(p => p.CityAddressInformations)
            //    //   .HasForeignKey(p => p.CityId)
            //    //   .OnDelete(DeleteBehavior.NoAction);
            //}
            //).ToTable("AddressInformation");


            //modelBuilder.Entity<Company>().OwnsOne<Address>(c => c.Address, a => {
            //    a.HasOne<Country>(c => c.Country).WithMany().HasForeignKey(a => a.CountryCode);
            //});
            //        builder.OwnsOne<AddressInformation>(z => z.AddressInformation, x => { x.WithOwner().HasForeignKey()})
            //        builder.OwnsOne<AddressInformation>(
            //subBuilder =>
            //{
            //    subBuilder.WithOwner().HasForeignKey("ApplicationUserId");
            //});
            builder.OwnsOne(m => m.PersonalInformation).ToTable("PersonalInformation");
            builder.OwnsMany(m => m.UserDocuments).ToTable("UserDocument");
            builder.OwnsMany(m => m.BankAccountInformations).ToTable("AccountInformation");
            builder.OwnsMany(m => m.UserLogins).ToTable("UserLogin");
        }
    }

}
