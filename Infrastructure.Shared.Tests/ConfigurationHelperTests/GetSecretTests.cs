using Infrastructure.Shared.Helpers;
using Infrastructure.Shared.Tests.TestData.ConfigurationHelper.GetSecret;

namespace Infrastructure.Shared.Tests.ConfigurationHelperTests;

public class GetSecretTests
{
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
        // Arrange & Act:
        var result = ConfigurationHelper.GetSecret(secretSectionName, userSecretsId);

        // Assert:
        Assert.False(string.IsNullOrWhiteSpace(result));
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
        // Arrange & Act:
        var result = ConfigurationHelper.GetSecret(secretSectionName, userSecretsId);

        // Assert:
        Assert.Null(result);
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
        // Arrange & Act & Assert:
        Assert.Throws<ArgumentException>(
            () => ConfigurationHelper.GetSecret(secretSectionName, userSecretsId));
    }
}
