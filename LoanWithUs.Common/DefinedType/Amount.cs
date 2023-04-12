using LoanWithUs.Common.Enum;

namespace LoanWithUs.Common.DefinedType
{
    public readonly record struct Amount(int amount, MoneyType moneyType)
    {
        public static Amount operator +(Amount a, Amount b)
        {
            if (a.moneyType != b.moneyType)
            {
                new Exception("Money Types are not equals!");
            }
            return new Amount(a.amount + b.amount, a.moneyType);
        }

        public static bool operator <(Amount a, Amount b)
        {
            if (a.moneyType != b.moneyType)
            {
                new Exception("Money Types are not equals!");
            }
            return a.amount<=b.amount;
        }


        public static bool operator >(Amount a, Amount b)
        {
            if (a.moneyType != b.moneyType)
            {
                new Exception("Money Types are not equals!");
            }
            return (a.amount >= b.amount);
        }

    }
}
