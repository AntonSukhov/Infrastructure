namespace Infrastructure.Shared.Services;

/// <summary>
/// Настройки параметров преобразования объектов в формат JSON и обратно.
/// </summary>
/// <typeparam name="TOptions">Тип данных, представляющий настройки преобразования.</typeparam>
public interface IJsonSerializationOptions<TOptions>
{
    #region Методы

    /// <summary>
    /// Получает настройки для преобразования объектов в формат JSON и обратно.
    /// </summary>
    /// <returns>Настройки необходимые для преобразования объектов в формат JSON и обратно.</returns>
    public TOptions GetOptions();

    #endregion
}
