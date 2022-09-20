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

            modelBuilder.Entity("LoanWithUs.Domain.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PrefixNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("City", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PrefixNumber = "041",
                            Title = "آذربایجان شرقی"
                        },
                        new
                        {
                            Id = 2,
                            PrefixNumber = "044",
                            Title = "آذربایجان غربی"
                        },
                        new
                        {
                            Id = 3,
                            PrefixNumber = "045",
                            Title = "اردبیل"
                        },
                        new
                        {
                            Id = 4,
                            PrefixNumber = "041",
                            Title = "اصفهان"
                        },
                        new
                        {
                            Id = 5,
                            PrefixNumber = "076",
                            Title = "البرز"
                        },
                        new
                        {
                            Id = 6,
                            PrefixNumber = "084",
                            Title = "ایلام"
                        },
                        new
                        {
                            Id = 7,
                            PrefixNumber = "077",
                            Title = "بوشهر"
                        },
                        new
                        {
                            Id = 8,
                            PrefixNumber = "021",
                            Title = "تهران"
                        },
                        new
                        {
                            Id = 9,
                            PrefixNumber = "038",
                            Title = "چهارمحال و بختیاری"
                        },
                        new
                        {
                            Id = 10,
                            PrefixNumber = "056",
                            Title = "خراسان جنوبی"
                        },
                        new
                        {
                            Id = 11,
                            PrefixNumber = "051",
                            Title = "خراسان رضوی"
                        },
                        new
                        {
                            Id = 12,
                            PrefixNumber = "058",
                            Title = "خراسان شمالی"
                        },
                        new
                        {
                            Id = 13,
                            PrefixNumber = "061",
                            Title = "خوزستان"
                        },
                        new
                        {
                            Id = 14,
                            PrefixNumber = "024",
                            Title = "زنجان"
                        },
                        new
                        {
                            Id = 15,
                            PrefixNumber = "023",
                            Title = "سمنان"
                        },
                        new
                        {
                            Id = 16,
                            PrefixNumber = "054",
                            Title = "سیستان و بلوچستان"
                        },
                        new
                        {
                            Id = 17,
                            PrefixNumber = "071",
                            Title = "فارس"
                        },
                        new
                        {
                            Id = 18,
                            PrefixNumber = "028",
                            Title = "قزوین"
                        },
                        new
                        {
                            Id = 19,
                            PrefixNumber = "025",
                            Title = "قم"
                        },
                        new
                        {
                            Id = 20,
                            PrefixNumber = "087",
                            Title = "کردستان"
                        },
                        new
                        {
                            Id = 21,
                            PrefixNumber = "034",
                            Title = "کرمان"
                        },
                        new
                        {
                            Id = 22,
                            PrefixNumber = "083",
                            Title = "کرمانشاه"
                        },
                        new
                        {
                            Id = 23,
                            PrefixNumber = "074",
                            Title = "کهگیلویه و بویراحمد"
                        },
                        new
                        {
                            Id = 24,
                            PrefixNumber = "017",
                            Title = "گلستان"
                        },
                        new
                        {
                            Id = 25,
                            PrefixNumber = "013",
                            Title = "گیلان"
                        },
                        new
                        {
                            Id = 26,
                            PrefixNumber = "066",
                            Title = "لرستان"
                        },
                        new
                        {
                            Id = 27,
                            PrefixNumber = "011",
                            Title = "مازندران"
                        },
                        new
                        {
                            Id = 28,
                            PrefixNumber = "086",
                            Title = "مرکزی"
                        },
                        new
                        {
                            Id = 29,
                            PrefixNumber = "076",
                            Title = "هرمزگان"
                        },
                        new
                        {
                            Id = 30,
                            PrefixNumber = "081",
                            Title = "همدان"
                        },
                        new
                        {
                            Id = 31,
                            PrefixNumber = "035",
                            Title = "یزد"
                        },
                        new
                        {
                            Id = 32,
                            PrefixNumber = "021",
                            ProvinceId = 8,
                            Title = "تهران"
                        },
                        new
                        {
                            Id = 33,
                            PrefixNumber = "021",
                            ProvinceId = 8,
                            Title = "شهریار"
                        },
                        new
                        {
                            Id = 34,
                            PrefixNumber = "021",
                            ProvinceId = 8,
                            Title = "اسلامشهر"
                        },
                        new
                        {
                            Id = 35,
                            PrefixNumber = "021",
                            ProvinceId = 8,
                            Title = "بهارستان"
                        },
                        new
                        {
                            Id = 36,
                            PrefixNumber = "021",
                            ProvinceId = 8,
                            Title = "پاکدشت"
                        },
                        new
                        {
                            Id = 37,
                            PrefixNumber = "021",
                            ProvinceId = 8,
                            Title = "ری"
                        },
                        new
                        {
                            Id = 38,
                            PrefixNumber = "021",
                            ProvinceId = 8,
                            Title = "قدس"
                        },
                        new
                        {
                            Id = 39,
                            PrefixNumber = "021",
                            ProvinceId = 8,
                            Title = "رباط کریم"
                        },
                        new
                        {
                            Id = 40,
                            PrefixNumber = "021",
                            ProvinceId = 8,
                            Title = "ورامین"
                        },
                        new
                        {
                            Id = 41,
                            PrefixNumber = "021",
                            ProvinceId = 8,
                            Title = "قرچک"
                        },
                        new
                        {
                            Id = 42,
                            PrefixNumber = "021",
                            ProvinceId = 8,
                            Title = "پردیس"
                        },
                        new
                        {
                            Id = 43,
                            PrefixNumber = "021",
                            ProvinceId = 8,
                            Title = "دماوند"
                        },
                        new
                        {
                            Id = 44,
                            PrefixNumber = "021",
                            ProvinceId = 8,
                            Title = "پیشوا"
                        },
                        new
                        {
                            Id = 45,
                            PrefixNumber = "021",
                            ProvinceId = 8,
                            Title = "شمیرانات"
                        },
                        new
                        {
                            Id = 46,
                            PrefixNumber = "021",
                            ProvinceId = 8,
                            Title = "فیروزکوه"
                        });
                });

            modelBuilder.Entity("LoanWithUs.Domain.LoanWithUsFile", b =>
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

            modelBuilder.Entity("LoanWithUs.Domain.UserAggregate.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("RegisterationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("RegisterationDate");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("LoanWithUs.Domain.UserAggregate.Applicant", b =>
                {
                    b.HasBaseType("LoanWithUs.Domain.UserAggregate.User");

                    b.ToTable("Applicant", (string)null);
                });

            modelBuilder.Entity("LoanWithUs.Domain.UserAggregate.Supporter", b =>
                {
                    b.HasBaseType("LoanWithUs.Domain.UserAggregate.User");

                    b.ToTable("Supporter", (string)null);
                });

            modelBuilder.Entity("LoanWithUs.Domain.City", b =>
                {
                    b.HasOne("LoanWithUs.Domain.City", "Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId");

                    b.Navigation("Province");
                });

            modelBuilder.Entity("LoanWithUs.Domain.UserAggregate.User", b =>
                {
                    b.OwnsOne("LoanWithUs.Domain.UserAggregate.AddressInformation", "AddressInformation", b1 =>
                        {
                            b1.Property<int>("UserId")
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

                            b1.HasKey("UserId");

                            b1.ToTable("AddressInformation", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsMany("LoanWithUs.Domain.UserAggregate.BankAccountInformation", "BankAccountInformations", b1 =>
                        {
                            b1.Property<int>("UserId")
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

                            b1.HasKey("UserId", "Id");

                            b1.ToTable("AccountInformation", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("LoanWithUs.Domain.UserAggregate.EducationalInformation", "EducationalInformation", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("EducationalSubject")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastEducationLevel")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.ToTable("EducationalInformation", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("LoanWithUs.Domain.UserAggregate.PersonalInformation", "PersonalInformation", b1 =>
                        {
                            b1.Property<int>("UserId")
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

                            b1.HasKey("UserId");

                            b1.ToTable("PersonalInformation", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("LoanWithUs.Domain.UserAggregate.UserConfirmation", "UserConfirmation", b1 =>
                        {
                            b1.Property<int>("UserId")
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

                            b1.HasKey("UserId");

                            b1.ToTable("UserConfirmation", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsMany("LoanWithUs.Domain.UserAggregate.UserDocument", "UserDocuments", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<int>("DocumentType")
                                .HasColumnType("int");

                            b1.Property<int>("FileId")
                                .HasColumnType("int");

                            b1.HasKey("UserId", "Id");

                            b1.HasIndex("FileId");

                            b1.ToTable("UserDocument", (string)null);

                            b1.HasOne("LoanWithUs.Domain.LoanWithUsFile", "File")
                                .WithMany()
                                .HasForeignKey("FileId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.Navigation("File");
                        });

                    b.OwnsMany("LoanWithUs.Domain.UserAggregate.UserLogin", "UserLogins", b1 =>
                        {
                            b1.Property<int>("UserId")
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

                            b1.HasKey("UserId", "Id");

                            b1.ToTable("UserLogin", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("AddressInformation")
                        .IsRequired();

                    b.Navigation("BankAccountInformations");

                    b.Navigation("EducationalInformation")
                        .IsRequired();

                    b.Navigation("PersonalInformation")
                        .IsRequired();

                    b.Navigation("UserConfirmation")
                        .IsRequired();

                    b.Navigation("UserDocuments");

                    b.Navigation("UserLogins");
                });

            modelBuilder.Entity("LoanWithUs.Domain.UserAggregate.Applicant", b =>
                {
                    b.HasOne("LoanWithUs.Domain.UserAggregate.User", null)
                        .WithOne()
                        .HasForeignKey("LoanWithUs.Domain.UserAggregate.Applicant", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

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
                                .IsUnique()
                                .HasFilter("[MobileNumber] IS NOT NULL");

                            b1.ToTable("Applicant");

                            b1.WithOwner()
                                .HasForeignKey("ApplicantId");
                        });

                    b.Navigation("IdentityInformation")
                        .IsRequired();
                });

            modelBuilder.Entity("LoanWithUs.Domain.UserAggregate.Supporter", b =>
                {
                    b.HasOne("LoanWithUs.Domain.UserAggregate.User", null)
                        .WithOne()
                        .HasForeignKey("LoanWithUs.Domain.UserAggregate.Supporter", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

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
                                .IsUnique()
                                .HasFilter("[MobileNumber] IS NOT NULL");

                            b1.ToTable("Supporter");

                            b1.WithOwner()
                                .HasForeignKey("SupporterId");
                        });

                    b.Navigation("IdentityInformation")
                        .IsRequired();
                });

            modelBuilder.Entity("LoanWithUs.Domain.City", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
