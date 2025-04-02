using System;
using System.IO;
using NUnit.Framework;

[TestFixture]
public class CryptographerTests
{
    private const string EncryptedDataFile = "ENCRYPTED_DATA_FILE_4_14";
    private const string DecryptedDataFile = "DECRYPTED_DATA_FILE_4_14";

    [Test]
    public void TestDecryptA()
    {
        byte[] encryptedData = File.ReadAllBytes(EncryptedDataFile);
        string result = Cryptographer.Decrypt(encryptedData, "test");

        string expected = File.ReadAllText(DecryptedDataFile);
        Assert.AreEqual(expected, result, "Decrypt should match expected result");
    }

    [Test]
    public void TestDecryptB()
    {
        byte[] encryptedData = File.ReadAllBytes(EncryptedDataFile);
        string result = Cryptographer.Decrypt(encryptedData, "test");

        string expected = File.ReadAllText(DecryptedDataFile);
        Assert.AreEqual(expected, result, "Again, decrypt should match expected");
    }
}
