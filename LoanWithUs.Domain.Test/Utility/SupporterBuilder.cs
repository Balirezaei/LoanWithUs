using LoanWithUs.Domain.UserAggregate;
using NSubstitute;

namespace LoanWithUs.Domain.Test.Utility
{
    public class SupporterBuilder
    {

        public Supporter Build()
        {
            var admin = new AdministratorBuilder().Build();
            var domainSupporter = Substitute.For<ISupporterDomainService>();

            return admin.DefineNewSupporter("1234567891","09113211212", domainSupporter);
        }
    }
}
