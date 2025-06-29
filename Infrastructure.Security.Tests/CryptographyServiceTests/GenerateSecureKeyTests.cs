using FluentAssertions;
using Infrastructure.Security.Services;
using Infrastructure.Security.Tests.TestData.CryptographyService.GenerateSecureKey;

namespace Infrastructure.Security.Tests.CryptographyServiceTests;

/// <summary>
/// Тесты для проверки метода генерации секретного ключа.
/// </summary>
public class GenerateSecureKeyTests
{
    #region Методы

    /// <summary>
    /// Тест проверки метода генерации секретного ключа для корректных входных параметров.
    /// </summary>
    /// <param name="keySize">Значение размера ключа.</param>
    [Theory]
    [ClassData(typeof(ForCorrectInputParamsTestData))]
    public void ForCorrectInputParams(int keySize)
    {
        var actual = CryptographyService.GenerateSecureKey(keySize);
        var expected = Convert.ToBase64String(new byte[keySize]).Length;

        actual.Should().NotBeNullOrWhiteSpace();
        actual.Length.Should().Be(expected);
    }

    /// <summary>
    /// Тест проверки метода генерации секретного ключа для некорректных входных параметров.
    /// </summary>
    /// <param name="keySize">Значение размера ключа.</param>
    [Theory]
    [ClassData(typeof(ForIncorrectInputParamsTestData))]
    public void ForIncorrectInputParams(int keySize)
    {
        var action = () => CryptographyService.GenerateSecureKey(keySize);

        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    #endregion
}
