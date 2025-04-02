using System;
using System.IO;
using NUnit.Framework;

[TestFixture]
public class CryptographerTests
{
    private const string EncryptedDataFile = "ENCRYPTED_DATA_FILE_4_14";
    private const string DecryptedDataFile = "DECRYPTED_DATA_FILE_4_14";

    [Test]
    public void TestDecrypt()
    {
        byte[] encryptedData = File.ReadAllBytes(EncryptedDataFile);
        byte[] expectedData = File.ReadAllBytes(DecryptedDataFile);
        string expectedResult = System.Text.Encoding.UTF8.GetString(expectedData);

        string result = Cryptographer.Decrypt(encryptedData, "test");
        Assert.AreEqual(expectedResult, result, "Testing simple decrypt");
    }

    [Test]
    public void TestEncrypt()
    {
        string xml = File.ReadAllText(DecryptedDataFile);
        byte[] encrypted = Cryptographer.Encrypt(xml, "test");
        string decrypted = Cryptographer.Decrypt(encrypted, "test");

        Assert.AreEqual(xml, decrypted, "Testing simple encrypt and decrypt");
    }
}
