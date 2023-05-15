using LoanWithUs.Common;
using LoanWithUs.Common.DefinedType;
using LoanWithUs.Common.ExtentionMethod;
using NSubstitute;

namespace LoanWithUs.Domain.Test.Utility
{
    public class SupporterBuilder
    {
        private Amount InitAmount;

        public SupporterBuilder()
        {
            InitAmount = StaticDataForBegining.InitCreditForSupporter.ToToman();
        }
        public SupporterBuilder WithInitAmount(int amount)
        {
            this.InitAmount = amount.ToToman();

            return this;
        }

        public Supporter Build()
        {
            var admin = new AdministratorBuilder().Build();
            var domainSupporter = Substitute.For<ISupporterDomainService>();
            IDateTimeServiceProvider dateProvider = new DateTimeServiceProvider();

            return admin.DefineNewSupporter("1234567891", new MobileNumber("09113211212"), InitAmount, domainSupporter, dateProvider);
        }
    }
}
