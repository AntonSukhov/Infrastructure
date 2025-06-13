using System.Text.Json;

namespace Infrastructure.Shared.Services;

/// <summary>
/// Настройки параметров преобразования объектов в формат JSON и обратно,
/// используя <see cref="System.Text.Json"/>.
/// </summary>
public class JsonSerializationOptions: IJsonSerializationOptions<JsonSerializerOptions>
{
    #region Поля
    private readonly JsonSerializerOptions _options;

    #endregion

    #region Конструкторы

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="JsonSerializationOptions"/> 
    /// с настройками по умолчанию.
    /// </summary>
    public JsonSerializationOptions()
    {
        _options = JsonSerializerOptions.Default;
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="JsonSerializationOptions"/> 
    /// с заданными настройками сериализации.
    /// </summary>
    /// <param name="options">Настройки сериализации, которые будут использоваться.</param>
    public JsonSerializationOptions(JsonSerializerOptions options)
    {
        _options = options ?? JsonSerializerOptions.Default;
    }

    #endregion

    #region Методы

    ///<inheritdoc/>
    public JsonSerializerOptions GetOptions() => _options;

    #endregion
}
