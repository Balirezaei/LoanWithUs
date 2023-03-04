using LoanWithUs.Common.Enum;

namespace LoanWithUs.Domain
{
    public class MoneyUnit
    {
        public static MoneyUnit NewToman()
        {
            return new MoneyUnit(MoneyType.Toman);
        }

        public MoneyUnit(MoneyType type)
        {
            Type = type;
        }

        public MoneyType Type { get; private set; }
    }

}
