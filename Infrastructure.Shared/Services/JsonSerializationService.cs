using System.Text;
using System.Text.Json;
using Infrastructure.Shared.Helpers;

namespace Infrastructure.Shared.Services;

/// <summary>
/// Сервис для преобразования объектов в формат JSON и обратно.
/// </summary>
public class JsonSerializationService : IJsonSerializationService
{
    #region Методы

    /// <inheritdoc/>
    public virtual async Task<string> SerializeAsync<TValue>(TValue value, JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        using var memoryStream = new MemoryStream();

        await JsonSerializer.SerializeAsync(memoryStream, value, options, cancellationToken);

        memoryStream.Position = 0L;

        using var reader = new StreamReader(memoryStream, Encoding.UTF8);

        return await reader.ReadToEndAsync(cancellationToken);
    }

    /// <inheritdoc/>
	public virtual async Task<TValue> DeserializeAsync<TValue>(string json, JsonSerializerOptions? options = null,
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
