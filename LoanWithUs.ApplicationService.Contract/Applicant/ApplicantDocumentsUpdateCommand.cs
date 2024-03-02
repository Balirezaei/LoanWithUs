using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class ApplicantDocumentsUpdateCommand : IRequest<ApplicantUpdateDocumentsResult>
    {
       public int ApplicantId { get; set; }
        public int[] FileId { get; set; }
    }
    public class ApplicantUpdateDocumentsResult
    {
        public string Message { get; set; }
        public  List<FileDto> Documents { get; set; }
    }
}