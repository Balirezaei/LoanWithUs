﻿using LoanWithUs.Common.DefinedType;

namespace LoanWithUs.Domain
{
    public interface ISupporterRepository
    {
        IQueryable<Supporter> GetAllSupporter();
        void Add(Supporter supporter);
        Task<bool> CheckNationalCode(int exceptCurrentUser, string nationalCode);
        Task<bool> CheckMobileNumber(int exceptCurrentUser, MobileNumber mobileNumber);
        Task<Supporter> GetSupporterById(int supporterId);
        Task<Supporter> GetSupporterByIdWithCreditInclude(int supporterId);
    }
}