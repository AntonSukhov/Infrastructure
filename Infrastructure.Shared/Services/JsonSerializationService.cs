using System.Text;
using System.Text.Json;
using Infrastructure.Shared.Helpers;

namespace Infrastructure.Shared.Services;

/// <summary>
/// Сервис для преобразования объектов в формат JSON и обратно.
/// </summary>
public static class JsonSerializationService
{
    #region Методы

    /// <summary>
    /// Асинхронно сериализует объект в строку формата JSON.
    /// </summary>
    /// <typeparam name="TValue">Тип объекта для сериализации.</typeparam>
    /// <param name="value">Объект, который нужно сериализовать.</param>
    /// <param name="options">Настройки сериализации.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Асинхронная задача, возвращающая строку в формате JSON.</returns>
    public static async Task<string> SerializeAsync<TValue>(TValue value,
        JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        using var memoryStream = new MemoryStream();

        await JsonSerializer.SerializeAsync(memoryStream, value, options, cancellationToken);

        memoryStream.Position = 0L;

        using var reader = new StreamReader(memoryStream, Encoding.UTF8);

        return await reader.ReadToEndAsync(cancellationToken);
    }

    /// <summary>
    /// Асинхронно десериализует строку в формате JSON в объект указанного типа.
    /// </summary>
    /// <typeparam name="TValue">Тип объекта для десериализации.</typeparam>
    /// <param name="json">Строка в формате JSON, которую нужно десериализовать.</param>
    /// <param name="options">Настройки десериализации.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Асинхронная задача, возвращающая десериализованный объект.</returns>
    /// <exception cref="JsonException">Выбрасывается, если результат десериализации равен null.</exception>
	public  static async Task<TValue> DeserializeAsync<TValue>(string json,
        JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(json, nameof(json));

        var jsonAsBytes = Encoding.UTF8.GetBytes(json);
        using var memoryStream = new MemoryStream(jsonAsBytes);

        var value = await JsonSerializer.DeserializeAsync<TValue>(memoryStream, options, cancellationToken);

        return value ?? throw new JsonException(ConstantsHelper.JsonDeserializationErrorMessage);
    }

    #endregion
}
