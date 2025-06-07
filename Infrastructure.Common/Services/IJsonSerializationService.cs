using System.Text.Json;

namespace Infrastructure.Common.Services;

/// <summary>
/// Сервис для преобразования объектов в формат JSON и обратно.
/// </summary>
public interface IJsonSerializationService
{
    #region Методы

    /// <summary>
    /// Асинхронно сериализует объект в строку формата JSON.
    /// </summary>
    /// <typeparam name="TValue">Тип объекта для сериализации.</typeparam>
    /// <param name="value">Объект, который нужно сериализовать.</param>
    /// <param name="options">Опции сериализации.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Асинхронная задача, возвращающая строку в формате JSON.</returns>
    Task<string> SerializeAsync<TValue>(TValue value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Асинхронно десериализует строку в формате JSON в объект указанного типа.
    /// </summary>
    /// <typeparam name="TValue">Тип объекта для десериализации.</typeparam>
    /// <param name="json">Строка в формате JSON, которую нужно десериализовать.</param>
    /// <param name="options">Опции десериализации.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Асинхронная задача, возвращающая десериализованный объект.</returns>
    /// <exception cref="JsonException">Выбрасывается, если результат десериализации равен null.</exception>
    Task<TValue> DeserializeAsync<TValue>(string json, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default);

    #endregion
}
