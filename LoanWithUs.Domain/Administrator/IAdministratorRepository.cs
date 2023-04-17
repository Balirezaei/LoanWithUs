
namespace LoanWithUs.Domain
{
    public interface IAdministratorRepository
    {
        Task<Administrator> CheckOtpCode(Guid key, string code, string userAgent);
        Task<Administrator> GetAdministratorByUserName(string userName);
        Task<Administrator> FindAdministratorById(int id);
    }
}
