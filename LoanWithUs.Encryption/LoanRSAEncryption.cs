using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace LoanWithUs.Encryption;
public class LoanRSAEncryption : ILoanRSAEncryption
{
    private readonly IRSAEncryptionConfig _config;

    public LoanRSAEncryption(IRSAEncryptionConfig config)
    {
        _config = config;
    }

    public RSA GetRSAWithPrivateKey()
    {
        var rsa = RSA.Create();
        rsa.ImportFromEncryptedPem(_config.PrivateKey, _config.PrivateKeyPassword);
        return rsa;
    }

    public RSA GetRsaWithPublicKey()
    {
        var rsa = RSA.Create();
        rsa.ImportFromPem(_config.PublicKey);
        return rsa;
    }
    public string EncryptInput(string input)
    {
        //var rsa = GetRsaWithPublicKey();
        //byte[] bytes = System.Text.Encoding.Default.GetBytes(input);
        //var encrypted = rsa.Encrypt(bytes, RSAEncryptionPadding.Pkcs1);
        //return Convert.ToBase64String(encrypted);

        var rsa = GetRsaWithPublicKey();
        return Convert.ToBase64String(rsa.Encrypt(System.Text.Encoding.Default.GetBytes(input), RSAEncryptionPadding.OaepSHA256));


    }

    public string DecryptInput(string input)
    {
        //var rsa = GetRSAWithPrivateKey();
        //byte[] bytes = System.Text.Encoding.Default.GetBytes(input);
        //var decrypted = rsa.Decrypt(bytes, RSAEncryptionPadding.Pkcs1);
        //return Convert.ToBase64String(decrypted);

        var rsa = GetRSAWithPrivateKey();
        byte[] textBytes = Convert.FromBase64String(input);
        byte[] decrypted = rsa.Decrypt(textBytes, RSAEncryptionPadding.OaepSHA256);
        return System.Text.Encoding.Default.GetString(decrypted);
    }
}
