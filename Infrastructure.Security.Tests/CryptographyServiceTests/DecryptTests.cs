using System.Security.Cryptography;
using FluentAssertions;
using Infrastructure.Security.Services;
using Infrastructure.Security.Tests.TestData.CryptographyService.Decrypt;

namespace Infrastructure.Security.Tests.CryptographyServiceTests;

/// <summary>
/// Тесты для проверки метода дешифрования строки с использованием AES.
/// </summary>
public class DecryptTests
{
    #region Методы

    /// <summary>
    /// Тест проверки метода дешифрования строки с использованием AES для корректных входных параметров.
    /// </summary>
    /// <param name="cipherText">Зашифрованный текст в виде строки Base64.</param>
    /// <param name="key">Ключ в виде строки Base64.</param>
    [Theory]
    [ClassData(typeof(ForCorrectInputParamsTestData))]
    public void ForCorrectInputParams(string cipherText, string key)
    {
        var actual = CryptographyService.Decrypt(cipherText, key);

        actual.Should().NotBeNullOrWhiteSpace()
                       .And
                       .Match(p => p == "Привет_мир!!!" || p == "text1177" || p == "64");
    }

    /// <summary>
    /// Тест проверки метода дешифрования строки с использованием AES для некорректных входных параметров.
    /// </summary>
    /// <param name="cipherText">Зашифрованный текст в виде строки Base64.</param>
    /// <param name="key">Ключ в виде строки Base64.</param>
    [Theory]
    [ClassData(typeof(ForIncorrectInputParamsTestData))]
    public void ForIncorrectInputParams(string cipherText, string key)
    {
        var action = () => CryptographyService.Decrypt(cipherText, key);

        var exception = action.Should().Throw<Exception>();

        exception.Match(p => p.Any(p1 => p1 is ArgumentException || p1 is ArgumentNullException || p1 is CryptographicException));
    }
    
    #endregion
}
