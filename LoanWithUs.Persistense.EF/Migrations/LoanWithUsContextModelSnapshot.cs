﻿// <auto-generated />
using System;
using LoanWithUs.Persistense.EF.ContextContainer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LoanWithUs.Persistense.EF.Migrations
{
    [DbContext(typeof(LoanWithUsContext))]
    partial class LoanWithUsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LoanWithUs.Domain.BasicInfo.LoanWithUsFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Extention")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("FileType")
                        .HasColumnType("int");

                    b.Property<string>("FileUrl")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("LoanWithUsFile", (string)null);
                });

            modelBuilder.Entity("LoanWithUs.Domain.UserAggregate.Applicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Applicant", (string)null);
                });

            modelBuilder.Entity("LoanWithUs.Domain.UserAggregate.Supporter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Supporter", (string)null);
                });

            modelBuilder.Entity("LoanWithUs.Domain.UserAggregate.Applicant", b =>
                {
                    b.OwnsOne("LoanWithUs.Domain.UserAggregate.AddressInformation", "AddressInformation", b1 =>
                        {
                            b1.Property<int>("ApplicantId")
                                .HasColumnType("int");

                            b1.Property<int>("CityId")
                                .HasColumnType("int");

                            b1.Property<string>("HomeAddress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("HomePhone")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("ProvinceId")
                                .HasColumnType("int");

                            b1.Property<string>("WorkAddress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("WorkPhone")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ApplicantId");

                            b1.ToTable("ApplicantAddressInformation", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ApplicantId");
                        });

                    b.OwnsMany("LoanWithUs.Domain.UserAggregate.BankAccountInformation", "BankAccountInformations", b1 =>
                        {
                            b1.Property<int>("ApplicantId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<string>("BankCartNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("BankName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ShabaNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ApplicantId", "Id");

                            b1.ToTable("ApplicantBankAccountInformation", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ApplicantId");
                        });

                    b.OwnsOne("LoanWithUs.Domain.UserAggregate.EducationalInformation", "EducationalInformation", b1 =>
                        {
                            b1.Property<int>("ApplicantId")
                                .HasColumnType("int");

                            b1.Property<string>("EducationalSubject")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastEducationTitle")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ApplicantId");

                            b1.ToTable("ApplicantEducationalInformation", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ApplicantId");
                        });

                    b.OwnsOne("LoanWithUs.Domain.UserAggregate.IdentityInformation", "IdentityInformation", b1 =>
                        {
                            b1.Property<int>("ApplicantId")
                                .HasColumnType("int");

                            b1.Property<string>("EmailAddress")
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)")
                                .HasColumnName("EmailAddress");

                            b1.Property<string>("MobileNumber")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)")
                                .HasColumnName("MobileNumber");

                            b1.Property<string>("NationalCode")
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)")
                                .HasColumnName("NationalCode");

                            b1.Property<string>("Password")
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("Password");

                            b1.HasKey("ApplicantId");

                            b1.HasIndex("MobileNumber")
                                .IsUnique();

                            b1.ToTable("Applicant");

                            b1.WithOwner()
                                .HasForeignKey("ApplicantId");
                        });

                    b.OwnsOne("LoanWithUs.Domain.UserAggregate.PersonalInformation", "PersonalInformation", b1 =>
                        {
                            b1.Property<int>("ApplicantId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("BirthDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("FatherFullName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("IdentityNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Job")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("MatherFullName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ApplicantId");

                            b1.ToTable("ApplicantPersonalInformation", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ApplicantId");
                        });

                    b.OwnsOne("LoanWithUs.Domain.UserAggregate.UserConfirmation", "UserConfirmation", b1 =>
                        {
                            b1.Property<int>("ApplicantId")
                                .HasColumnType("int");

                            b1.Property<bool>("HomePhoneConfirmation")
                                .HasColumnType("bit");

                            b1.Property<bool>("MobileConfirmation")
                                .HasColumnType("bit");

                            b1.Property<bool>("NationalCodeConfirmation")
                                .HasColumnType("bit");

                            b1.Property<bool>("PostalCodeConfirmation")
                                .HasColumnType("bit");

                            b1.Property<bool>("TotalConfirmation")
                                .HasColumnType("bit");

                            b1.Property<bool>("UserBanckAccountConfirmation")
                                .HasColumnType("bit");

                            b1.HasKey("ApplicantId");

                            b1.ToTable("ApplicantUserConfirmation", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ApplicantId");
                        });

                    b.OwnsMany("LoanWithUs.Domain.UserAggregate.UserDocument", "UserDocuments", b1 =>
                        {
                            b1.Property<int>("ApplicantId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<int>("DocumentType")
                                .HasColumnType("int");

                            b1.Property<int>("FileId")
                                .HasColumnType("int");

                            b1.HasKey("ApplicantId", "Id");

                            b1.HasIndex("FileId");

                            b1.ToTable("ApplicantUserDocument", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ApplicantId");

                            b1.HasOne("LoanWithUs.Domain.BasicInfo.LoanWithUsFile", "File")
                                .WithMany()
                                .HasForeignKey("FileId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.Navigation("File");
                        });

                    b.OwnsMany("LoanWithUs.Domain.UserAggregate.UserLogin", "UserLogins", b1 =>
                        {
                            b1.Property<int>("ApplicantId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("ExpireDate")
                                .HasColumnType("datetime2");

                            b1.HasKey("ApplicantId", "Id");

                            b1.ToTable("ApplicantUserLogin", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ApplicantId");
                        });

                    b.Navigation("AddressInformation")
                        .IsRequired();

                    b.Navigation("BankAccountInformations");

                    b.Navigation("EducationalInformation")
                        .IsRequired();

                    b.Navigation("IdentityInformation")
                        .IsRequired();

                    b.Navigation("PersonalInformation")
                        .IsRequired();

                    b.Navigation("UserConfirmation")
                        .IsRequired();

                    b.Navigation("UserDocuments");

                    b.Navigation("UserLogins");
                });

            modelBuilder.Entity("LoanWithUs.Domain.UserAggregate.Supporter", b =>
                {
                    b.OwnsOne("LoanWithUs.Domain.UserAggregate.AddressInformation", "AddressInformation", b1 =>
                        {
                            b1.Property<int>("SupporterId")
                                .HasColumnType("int");

                            b1.Property<int>("CityId")
                                .HasColumnType("int");

                            b1.Property<string>("HomeAddress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("HomePhone")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("ProvinceId")
                                .HasColumnType("int");

                            b1.Property<string>("WorkAddress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("WorkPhone")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SupporterId");

                            b1.ToTable("SupporterAddressInformation", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("SupporterId");
                        });

                    b.OwnsMany("LoanWithUs.Domain.UserAggregate.BankAccountInformation", "BankAccountInformations", b1 =>
                        {
                            b1.Property<int>("SupporterId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<string>("BankCartNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("BankName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ShabaNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SupporterId", "Id");

                            b1.ToTable("SupporterBankAccountInformation", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("SupporterId");
                        });

                    b.OwnsOne("LoanWithUs.Domain.UserAggregate.EducationalInformation", "EducationalInformation", b1 =>
                        {
                            b1.Property<int>("SupporterId")
                                .HasColumnType("int");

                            b1.Property<string>("EducationalSubject")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastEducationTitle")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SupporterId");

                            b1.ToTable("SupporterEducationalInformation", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("SupporterId");
                        });

                    b.OwnsOne("LoanWithUs.Domain.UserAggregate.IdentityInformation", "IdentityInformation", b1 =>
                        {
                            b1.Property<int>("SupporterId")
                                .HasColumnType("int");

                            b1.Property<string>("EmailAddress")
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)")
                                .HasColumnName("EmailAddress");

                            b1.Property<string>("MobileNumber")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)")
                                .HasColumnName("MobileNumber");

                            b1.Property<string>("NationalCode")
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)")
                                .HasColumnName("NationalCode");

                            b1.Property<string>("Password")
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("Password");

                            b1.HasKey("SupporterId");

                            b1.HasIndex("MobileNumber")
                                .IsUnique();

                            b1.ToTable("Supporter");

                            b1.WithOwner()
                                .HasForeignKey("SupporterId");
                        });

                    b.OwnsOne("LoanWithUs.Domain.UserAggregate.PersonalInformation", "PersonalInformation", b1 =>
                        {
                            b1.Property<int>("SupporterId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("BirthDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("FatherFullName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("IdentityNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Job")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("MatherFullName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SupporterId");

                            b1.ToTable("SupporterPersonalInformation", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("SupporterId");
                        });

                    b.OwnsOne("LoanWithUs.Domain.UserAggregate.UserConfirmation", "UserConfirmation", b1 =>
                        {
                            b1.Property<int>("SupporterId")
                                .HasColumnType("int");

                            b1.Property<bool>("HomePhoneConfirmation")
                                .HasColumnType("bit");

                            b1.Property<bool>("MobileConfirmation")
                                .HasColumnType("bit");

                            b1.Property<bool>("NationalCodeConfirmation")
                                .HasColumnType("bit");

                            b1.Property<bool>("PostalCodeConfirmation")
                                .HasColumnType("bit");

                            b1.Property<bool>("TotalConfirmation")
                                .HasColumnType("bit");

                            b1.Property<bool>("UserBanckAccountConfirmation")
                                .HasColumnType("bit");

                            b1.HasKey("SupporterId");

                            b1.ToTable("SupporterUserConfirmation", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("SupporterId");
                        });

                    b.OwnsMany("LoanWithUs.Domain.UserAggregate.UserDocument", "UserDocuments", b1 =>
                        {
                            b1.Property<int>("SupporterId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<int>("DocumentType")
                                .HasColumnType("int");

                            b1.Property<int>("FileId")
                                .HasColumnType("int");

                            b1.HasKey("SupporterId", "Id");

                            b1.HasIndex("FileId");

                            b1.ToTable("SupporterUserDocument", (string)null);

                            b1.HasOne("LoanWithUs.Domain.BasicInfo.LoanWithUsFile", "File")
                                .WithMany()
                                .HasForeignKey("FileId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("SupporterId");

                            b1.Navigation("File");
                        });

                    b.OwnsMany("LoanWithUs.Domain.UserAggregate.UserLogin", "UserLogins", b1 =>
                        {
                            b1.Property<int>("SupporterId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("ExpireDate")
                                .HasColumnType("datetime2");

                            b1.HasKey("SupporterId", "Id");

                            b1.ToTable("SupporterUserLogin", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("SupporterId");
                        });

                    b.Navigation("AddressInformation")
                        .IsRequired();

                    b.Navigation("BankAccountInformations");

                    b.Navigation("EducationalInformation")
                        .IsRequired();

                    b.Navigation("IdentityInformation")
                        .IsRequired();

                    b.Navigation("PersonalInformation")
                        .IsRequired();

                    b.Navigation("UserConfirmation")
                        .IsRequired();

                    b.Navigation("UserDocuments");

                    b.Navigation("UserLogins");
                });
#pragma warning restore 612, 618
        }
    }
}
