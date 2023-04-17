using LoanWithUs.Common.DefinedType;
using LoanWithUs.Domain;
using NSubstitute;

namespace LoanWithUs.Domain.Test.Utility
{
    public class SupporterBuilder
    {
        public Supporter Build()
        {
            var admin = new AdministratorBuilder().Build();
            var domainSupporter = Substitute.For<ISupporterDomainService>();

            return admin.DefineNewSupporter("1234567891",new MobileNumber("09113211212"), domainSupporter);
        }
    }
}
