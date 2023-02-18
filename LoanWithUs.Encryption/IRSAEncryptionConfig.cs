namespace LoanWithUs.Encryption;

public interface IRSAEncryptionConfig{
 string PublicKey
    {
        get;
    }
  string PrivateKey
    {
        get;
    }
    string PrivateKeyPassword
    {
        get;
    }

}

