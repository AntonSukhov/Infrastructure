namespace Infrastructure.Testing.Common;

/// <summary>
/// Входные данные тестового сценария.
/// </summary>
/// <typeparam name="TIn">Тип входных данных.</typeparam>
public class TestCaseInput<TIn>
{
    #region Свойства

    /// <summary>
    /// Получает или задает порядковый номер тестового сценария.
    /// </summary>
    public required int ScenarioNumber { get; set; }

    /// <summary>
    /// Получает или задает входные данные для теста.
    /// </summary>
    public required TIn InputData { get; set; }

    /// <summary>
    /// Получает или задает описание тестового сценария.
    /// </summary>
    public required string Description { get; set; }

    #endregion
}

