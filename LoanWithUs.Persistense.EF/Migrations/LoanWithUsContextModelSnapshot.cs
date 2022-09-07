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

            modelBuilder.Entity("LoanWithUs.Domain.UserAggregate.Applicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Applicant", (string)null);
                });

            modelBuilder.Entity("LoanWithUs.Domain.UserAggregate.LoanWithUsFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Extention")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoanWithUsFile");
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

                            b1.ToTable("AddressInformation", (string)null);

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

                            b1.ToTable("EducationalInformation", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ApplicantId");
                        });

                    b.OwnsOne("LoanWithUs.Domain.UserAggregate.IdentityInformation", "IdentityInformation", b1 =>
                        {
                            b1.Property<int>("ApplicantId")
                                .HasColumnType("int");

                            b1.Property<string>("EmailAddress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("MobileNumber")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("NationalCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ApplicantId");

                            b1.ToTable("IdentityInformation", (string)null);

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

                            b1.ToTable("PersonalInformation", (string)null);

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

                            b1.ToTable("UserConfirmation", (string)null);

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

                            b1.ToTable("UserDocument", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ApplicantId");

                            b1.HasOne("LoanWithUs.Domain.UserAggregate.LoanWithUsFile", "File")
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

                            b1.ToTable("UserLogin", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ApplicantId");
                        });

                    b.Navigation("AddressInformation")
                        .IsRequired();

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