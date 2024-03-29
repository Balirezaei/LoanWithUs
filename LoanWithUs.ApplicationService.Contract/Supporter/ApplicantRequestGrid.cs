﻿using LoanWithUs.Common.Enum;

namespace LoanWithUs.ApplicationService.Contract
{
    public class ApplicantRequestGrid
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public string ApplicantFullName { get; set; }
        public ApplicantLoanRequestState State { get; set; }
        public string StateDescription { get; set; }
        public int Amount { get; set; }
        public int InstallmentsCount { get; set; }
        public string TrackingNumber { get; set; }
        public string CreateDate { get; set; }
    }
}
