using System.Text;
using System.Text.Json;
using Infrastructure.Networks.Enums;
using Infrastructure.Shared.Services;

namespace Infrastructure.Networks.Extensions;

/// <summary>
/// Расширение класса <see cref="HttpClient"/>. 
/// </summary>
public static class HttpClientExtension
{
    #region Методы

    /// <summary>
    /// Асинхронно отправляет POST-запрос с объектом в формате JSON и получает ответ в виде объекта.
    /// </summary>
    /// <typeparam name="TInput">Тип объекта, который будет отправлен в запросе.</typeparam>
    /// <typeparam name="TOutput">Тип объекта, который будет получен в ответе.</typeparam>
    /// <param name="client">Экземпляр <see cref="HttpClient"/>, используемый для отправки запроса.</param>
    /// <param name="url">URL-адрес, на который будет отправлен запрос.</param>
    /// <param name="inputObject">Объект, который будет сериализован и отправлен в запросе.</param>
    /// <param name="options">Настройки сериализации и десериализации объекта в JSON и обратно. Может быть null.</param>
    /// <param name="mediaType">Тип медиа-контента, по умолчанию <see cref="MediaType.Json"/>.</param>
    /// <returns>Асинхронная задача, возвращающая десериализованный объект ответа или null в случае ошибки.</returns>
	public static async Task<TOutput?> PostAsync<TInput, TOutput>(this HttpClient client, string url,
        TInput inputObject, JsonSerializerOptions? options = null, MediaType mediaType =  MediaType.Json)
    {
        ArgumentNullException.ThrowIfNull(client);        
        ArgumentException.ThrowIfNullOrWhiteSpace(url);

        var mediaTypeAsString = mediaType.ToMediaTypeString();

        var content = await JsonSerializationService.SerializeAsync(inputObject, options);
        using var contentAsString = new StringContent(content, Encoding.UTF8, mediaTypeAsString);

        var response = await client.PostAsync(url, contentAsString);
        response.EnsureSuccessStatusCode();

        var responseContentAsString = await response.Content.ReadAsStringAsync();

        var output = await JsonSerializationService.DeserializeAsync<TOutput>(responseContentAsString, options);
        
        return output;
	}

    #endregion
}
