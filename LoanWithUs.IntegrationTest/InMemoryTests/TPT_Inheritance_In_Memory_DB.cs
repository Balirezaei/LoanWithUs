using FluentAssertions;
using LoanWithUs.Common;
using LoanWithUs.Domain;
using LoanWithUs.IntegrationTest.Utility.WebFactory;

namespace LoanWithUs.IntegrationTest.InMemoryTests
{
    public partial class TPT_Inheritance_In_Memory_DB : IClassFixture<InMemoryApplicationFactory>
    {
        private readonly InMemoryApplicationFactory _factory;

        public TPT_Inheritance_In_Memory_DB()
        {
            _factory = new InMemoryApplicationFactory();
        }

        //[Fact]
        //public async Task SimpleInsertToApplicantShouldWorkCorrectly()
        //{
        //    //Fixture Setup
        //    var client = _factory.CreateClient();
        //    var repo = (IApplicantRepository)_factory.Services.GetService(typeof(IApplicantRepository));
        //    var readRepo = (IApplicantReadRepository)_factory.Services.GetService(typeof(IApplicantReadRepository));
        //    var unitOfWork = (IUnitOfWork)_factory.Services.GetService(typeof(IUnitOfWork));

        //    //Exercise
        //    Applicant expectedApplicant = new ApplicantBuilder().Build();
        //    repo.CreateApplicant(expectedApplicant);
        //    await unitOfWork.CommitAsync();

        //    var actualApplicant = await readRepo.FindApplicantById(expectedApplicant.Id);

        //    //Assertion
        //    actualApplicant.IdentityInformation.MobileNumber.Should().Be(expectedApplicant.IdentityInformation.MobileNumber);

        //    //TearDown
        //}


        //[Fact]
        //public async Task SimpleInsertToSupporterShouldWorkCorrectly()
        //{
        //    //Fixture Setup
        //    var client = _factory.CreateClient();
        //    var repo = (IApplicantRepository)_factory.Services.GetService(typeof(IApplicantRepository));
        //    var readRepo = (IApplicantReadRepository)_factory.Services.GetService(typeof(IApplicantReadRepository));
        //    var unitOfWork = (IUnitOfWork)_factory.Services.GetService(typeof(IUnitOfWork));

        //    //Exercise
        //    Applicant expectedApplicant = new ApplicantBuilder().Build();
        //    repo.CreateApplicant(expectedApplicant);
        //    await unitOfWork.CommitAsync();

        //    var actualApplicant = await readRepo.FindApplicantById(expectedApplicant.Id);

        //    //Assertion
        //    actualApplicant.IdentityInformation.MobileNumber.Should().Be(expectedApplicant.IdentityInformation.MobileNumber);

        //    //TearDown
        //}
    }
}