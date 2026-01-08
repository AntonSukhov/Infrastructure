namespace Infrastructure.Testing.Common;

/// <summary>
/// Базовый тестовый сценарий.
/// </summary>
public class TestCaseBase
{
    /// <summary>
    /// Получает или задает порядковый номер тестового сценария.
    /// </summary>
    public required int ScenarioNumber { get; set; }

    /// <summary>
    /// Получает или задает описание тестового сценария.
    /// </summary>
    public required string Description { get; set; }

}
