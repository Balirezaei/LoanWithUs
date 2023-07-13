using LoanWithUs.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanWithUs.Persistense.EF.EfConfiguration
{
    public class LoanWithUsFileConfiguration : IEntityTypeConfiguration<LoanWithUsFile>
    {
        public void Configure(EntityTypeBuilder<LoanWithUsFile> builder)
        {
            builder.HasKey(m => m.Id);
            builder.ToTable("LoanWithUsFile");
            builder.Property(m => m.FileUrl).HasMaxLength(250);
            builder.Property(m => m.FileName).HasMaxLength(250);
            builder.Property(m => m.Extention).HasMaxLength(10);
            builder.Property(m => m.Path).HasMaxLength(250);
        }
    }

}
