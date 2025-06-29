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

    /// <summary>
    /// Шифрует строку с использованием AES.
    /// </summary>
    /// <param name="plainText">Текст для шифрования.</param>
    /// <param name="key">Ключ в виде строки Base64.</param>
    /// <returns>Зашифрованный текст в виде строки Base64.</returns>
    public static string Encrypt(string plainText, string key)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(plainText);
        ArgumentException.ThrowIfNullOrWhiteSpace(key);

        using var cryptoObj = Aes.Create();
        cryptoObj.Key = Convert.FromBase64String(key);
        cryptoObj.GenerateIV(); // Генерируем новый вектор инициализации (IV)

        using var memoryStream = new MemoryStream();
        memoryStream.Write(buffer: cryptoObj.IV, offset: 0, count: cryptoObj.IV.Length); // Записываем IV в начало потока

        using (var encryptorObj = cryptoObj.CreateEncryptor(cryptoObj.Key, cryptoObj.IV))
        using (var cryptoStream = new CryptoStream(memoryStream, encryptorObj, CryptoStreamMode.Write))
        using (var streamWriter = new StreamWriter(cryptoStream))
        {
            streamWriter.Write(plainText);
        }

        return Convert.ToBase64String(memoryStream.ToArray());
    }

    /// <summary>
    /// Дешифрует строку с использованием AES.
    /// </summary>
    /// <param name="cipherText">Зашифрованный текст в виде строки Base64.</param>
    /// <param name="key">Ключ в виде строки Base64.</param>
    /// <returns>Расшифрованный текст.</returns>
    public static string Decrypt(string cipherText, string key)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cipherText);
        ArgumentException.ThrowIfNullOrWhiteSpace(key);

        var fullCipher = Convert.FromBase64String(cipherText);

        using var cryptoObj = Aes.Create();
        cryptoObj.Key = Convert.FromBase64String(key);

        var iv = new byte[cryptoObj.BlockSize / 8];
        Array.Copy(sourceArray: fullCipher, sourceIndex: 0,
            destinationArray: iv, destinationIndex: 0, length: iv.Length); // Извлекаем IV из начала зашифрованного текста

        using var memoryStream = new MemoryStream(fullCipher, iv.Length, fullCipher.Length - iv.Length);

        using var decryptorObj = cryptoObj.CreateDecryptor(cryptoObj.Key, iv);
        using var cryptoStream = new CryptoStream(memoryStream, decryptorObj, CryptoStreamMode.Read);
        using var streamReader = new StreamReader(cryptoStream);

        return streamReader.ReadToEnd();
    }

    #endregion
}