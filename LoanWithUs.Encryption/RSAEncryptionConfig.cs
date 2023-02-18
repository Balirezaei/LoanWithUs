namespace LoanWithUs.Encryption;

public class RSAEncryptionConfig : IRSAEncryptionConfig
{
private readonly string _privatekeyDir;
private readonly string _privateKey;
private readonly string _publickeyDir;
private readonly string _publickey;
private readonly string _privateKeyPassword;

    public RSAEncryptionConfig(string privatekeyDir, string publickeyDir,string privateKeyPassword)
    {
        _privatekeyDir = privatekeyDir;
        _privateKey=  File.ReadAllText(_privatekeyDir);
        _publickeyDir = publickeyDir;
        _publickey=  File.ReadAllText(_publickeyDir);
        _privateKeyPassword = privateKeyPassword;
    }

    public string PrivateKey=> _privateKey;
    public string PublicKey=> _publickey;

    public string PrivateKeyPassword => _privateKeyPassword;
}

