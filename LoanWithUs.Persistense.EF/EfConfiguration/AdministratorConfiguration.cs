using LoanWithUs.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Persistense.EF.EfConfiguration
{

    public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.ToTable("Administrator");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.FirstName).HasMaxLength(50);
            builder.Property(m => m.LastName).HasMaxLength(50);
            builder.Property(m => m.NationalCode).HasMaxLength(10);
            builder.Property(m => m.MobileNumber).HasMaxLength(12);
            builder.OwnsMany(m => m.UserLogins).ToTable("AdminLogin");
            builder.HasData(new object[] {
                    new {
                        Id =  1,
                        FirstName="Admin",
                        LastName ="admin",
                        MobileNumber ="09124444444",
                        NationalCode ="0099887766",
                        UserName ="admin",
                        Password ="o4r8d5bV0uH4wxMOIP+8SG8plc4dLZ4iUsgbUonSDL+y1wEWURrhqJEeK7qpyViSZMpVZOhDWbtiEPt00fZr2vWfjKDgEIA8982GNs+Atr2PRpV3+8epUbP6egn4ifS1UsGV3iiZJj3cdMLczNkvBAV05BKi97L+OVQaj4b741gsrDw5p2oa2CE6BLAMAcFfxBpLSuYnLfycfQJlQ7nxP10eSCpeLEpnuX+YqextxzkL1510HPkpJxHspruuijuT3LFMrhqWnNr0e7YuJlft3354QYLkGXAIn2zJYEo/ppfpVXe7IAI9zx7FsLPgXD3z62gEjJHiF+TjeegmDuQ5CA==",
                        RegisterationDate=DateTime.Now,
                    }
            });

        }
    }
}
