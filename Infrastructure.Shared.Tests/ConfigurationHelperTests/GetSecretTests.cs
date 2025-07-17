using FluentAssertions;
using Infrastructure.Shared.Helpers;
using Infrastructure.Shared.Tests.TestData.ConfigurationHelper.GetSecret;

namespace Infrastructure.Shared.Tests.ConfigurationHelperTests;

public class GetSecretTests
{
    #region Методы

    /// <summary>
    /// Тест проверки метода получения секрета для существующего значения Название секции файла секретов для секрета
    /// и Идентификатора секрета.
    /// </summary>
    /// <param name="secretSectionName">Название секции файла секретов для секрета.</param>
    /// <param name="userSecretsId">Идентификатор секрета.</param>
    [Theory]
    [ClassData(typeof(ForExistedSecretSectionNameAndUsersecretsIdTestData))]
    public void ForExistedSecretSectionNameAndUsersecretsId(string secretSectionName, string userSecretsId)
    {
        var actual = ConfigurationHelper.GetSecret(secretSectionName, userSecretsId);

        actual.Should().NotBeNullOrWhiteSpace();
    }

    /// <summary>
    /// Тест проверки метода получения секрета для несуществующего значения Название секции файла секретов для секрета
    /// или Идентификатора секрета.
    /// </summary>
    /// <param name="secretSectionName">Название секции файла секретов для секрета.</param>
    /// <param name="userSecretsId">Идентификатор секрета.</param>
    [Theory]
    [ClassData(typeof(ForNotExistedSecretSectionNameAndUsersecretsIdTestData))]
    public void ForNotExistedSecretSectionNameAndUsersecretsId(string secretSectionName, string userSecretsId)
    {
        var actual = ConfigurationHelper.GetSecret(secretSectionName, userSecretsId);

        actual.Should().BeNull();
    }

    /// <summary>
    /// Тест проверки метода получения секрета для некорректных значений Название секции файла секретов для секрета
    /// или Идентификатора секрета.
    /// </summary>
    /// <param name="secretSectionName">Название секции файла секретов для секрета.</param>
    /// <param name="userSecretsId">Идентификатор секрета.</param>
    [Theory]
    [ClassData(typeof(ForIncorrectInputParamsTestData))]
    public void ForIncorrectInputParams(string secretSectionName, string userSecretsId)
    {
        var func = () => ConfigurationHelper.GetSecret(secretSectionName, userSecretsId);

        func.Should().Throw<ArgumentException>();
    }

    #endregion
}
