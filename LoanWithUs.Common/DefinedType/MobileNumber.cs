using LoanWithUs.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Common.DefinedType
{
    public readonly record struct MobileNumber(string mobileNumber)
    {
        public override string ToString()
        {
            return this.mobileNumber;
        }
    }
    public readonly record struct Amount(int amount, MoneyType moneyType);
}
