using System.Security.Cryptography;

namespace Infrastructure.Security.Services;

/// <summary>
/// Сервис криптографии.
/// </summary>
public static class CryptographyService
{
    #region Поля

    /// <summary>
    /// Размер ключа по умолчанию в байтах.
    /// </summary>
    private const int DefaultKeySize = 64;

    #endregion

    #region Методы

    /// <summary>
    /// Генерирует секретный ключ заданного размера для использования с HMAC.
    /// </summary>
    /// <param name="keySize">Размер ключа в байтах. Должен быть положительным числом. По умолчанию 64 байта (512 бит).</param>
    /// <returns>Ключ в виде строки Base64.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Возникает, если размер ключа меньше или равен нулю, или превышает максимальный размер.</exception>
    public static string GenerateSecureKey(int keySize = DefaultKeySize)
    {
        if (keySize <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(keySize), "Размер ключа должен быть положительным.");
        }

        if (keySize > DefaultKeySize)
        {
            throw new ArgumentOutOfRangeException(nameof(keySize), $"Размер ключа не должен превышать {DefaultKeySize} байт.");
        }

        var keyBytes = new byte[keySize];

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(keyBytes);
        }

        return Convert.ToBase64String(keyBytes);
    }

    #endregion
}