using System.Security.Cryptography;
using FluentAssertions;
using Infrastructure.Security.Services;
using Infrastructure.Security.Tests.TestData.CryptographyService.Encrypt;

namespace Infrastructure.Security.Tests.CryptographyServiceTests;

/// <summary>
/// Тесты для проверки метода шифрования строки с использованием AES.
/// </summary>
public class EncryptTests
{
    #region Методы

    /// <summary>
    /// Тест проверки метода шифрования строки с использованием AES для корректных входных параметров.
    /// </summary>
    /// <param name="plainText">Текст для шифрования.</param>
    /// <param name="key">Ключ в виде строки Base64.</param>
    [Theory]
    [ClassData(typeof(ForCorrectInputParamsTestData))]
    public void ForCorrectInputParams(string plainText, string key)
    {
        var actual = CryptographyService.Encrypt(plainText, key);

        actual.Should().NotBeNullOrWhiteSpace();
    }

    /// <summary>
    /// Тест проверки метода шифрования строки с использованием AES для некорректных входных параметров.
    /// </summary>
    /// <param name="plainText">Текст для шифрования.</param>
    /// <param name="key">Ключ в виде строки Base64.</param>
    [Theory]
    [ClassData(typeof(ForIncorrectInputParamsTestData))]
    public void ForIncorrectInputParams(string plainText, string key)
    {
        var action = () => CryptographyService.Encrypt(plainText, key);

        var exception = action.Should().Throw<Exception>();

        exception.Match(p => p.Any(p1 => p1 is ArgumentException || p1 is ArgumentNullException || p1 is CryptographicException));
    }

    [Fact]
    public void Method()
    {
        var text = "Hello World!!!";
        var message = string.Empty;
        var secureKey32BitSize = 32;
        var secureKey64BitSize = 64;

        var secureKey32Bit = CryptographyService.GenerateSecureKey(secureKey32BitSize);
        var secureKey64Bit = CryptographyService.GenerateSecureKey(secureKey64BitSize);
        var secureKey64BitLength = Convert.ToBase64String(new byte[secureKey64BitSize]).Length;

        if (!string.IsNullOrWhiteSpace(secureKey64Bit) &&
            secureKey64Bit.Length == secureKey64BitLength)
        {
            message = "The generate secure key was successful!";
        }
        else
        {
            message = "The generate secure key was unsuccessful!";
        }

        Console.WriteLine(message);

        var encryptText = CryptographyService.Encrypt(text, secureKey32Bit);
        var decryptText = CryptographyService.Decrypt(encryptText, secureKey32Bit);

        if (!string.IsNullOrWhiteSpace(encryptText) &&
            text == decryptText)
        {
            message = "The encrypt and decrypt was successful!";
        }
        else
        {
            message = "The encrypt and decrypt was unsuccessful!";
        }
        
        Console.WriteLine(message);
    }

    #endregion
}
