using Microsoft.Extensions.Configuration;

namespace Infrastructure.Shared.Helpers;

/// <summary>
/// Помощник в работе с конфигурациями.
/// </summary>
public static class ConfigurationHelper
{
    #region Методы

    /// <summary>
    /// Получает значение секрета.
    /// </summary>
    /// <param name="secretSectionName">Название секции файла секретов для секрета.</param>
    /// <param name="userSecretsId">Идентификатор секрета.</param>
    /// <returns>Секрет.</returns>
    public static string? GetSecret(string secretSectionName, string userSecretsId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(secretSectionName);
        ArgumentException.ThrowIfNullOrWhiteSpace(userSecretsId);

        var configuration = new ConfigurationBuilder().AddUserSecrets(userSecretsId)
                                                      .Build();

        return configuration[secretSectionName];
    }

    #endregion
}
