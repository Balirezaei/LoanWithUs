// Directory.GetCurrentDirectory(),
// "Keys",
// Configuration.GetValue<String>("PublicKey")
using FluentAssertions;
using LoanWithUs.Encryption;

namespace LoanWithUs.IntegrationTest
{
    public class RsaUnitTest
    {
        [Fact]
        public void EncryptionAnddecryptionWithPublicAndPrivateKeyShouldWorkCorrectly()
        {
            //Fixture Setup
            var privatekeyDir = Path.Combine(Directory.GetCurrentDirectory(), "Keys", "private_loan.pem");
            var publickeyDir = Path.Combine(Directory.GetCurrentDirectory(), "Keys", "public_loan.pem");
            var config = new RSAEncryptionConfig(privatekeyDir, publickeyDir, "!QAZ2wsx");
            var loanRSAEncryption = new LoanRSAEncryption(config);
            var textToEcrypt = "!2#4%6";

            //Exersice
            var encrypted = loanRSAEncryption.EncryptInput(textToEcrypt);

            var decrypted = loanRSAEncryption.DecryptInput(encrypted);
            //Verification

            decrypted.Should().Be(textToEcrypt);
            //TearDown
        }
    }
}