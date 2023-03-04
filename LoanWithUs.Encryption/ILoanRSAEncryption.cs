using System.Security.Cryptography;

namespace LoanWithUs.Encryption;

public interface ILoanRSAEncryption{
    RSA GetRSAWithPrivateKey();
    RSA GetRsaWithPublicKey();
    string EncryptInput(string input);
     string DecryptInput(string input);
}
