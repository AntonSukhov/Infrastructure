using Infrastructure.Testing.Common;

namespace Infrastructure.Testing.TestCases;

/// <summary>
/// Тестовый сценарий с выходными данными.
/// </summary>
/// <typeparam name="TOut">Тип выходных данных.</typeparam>
public class TestCaseResult<TOut>: TestCaseBase
{
    #region Свойства

    /// <summary>
    /// Получает или задает ожидаемые выходные данные сценария.
    /// </summary>
    public required TOut OutputData { get; set; }

    #endregion
}
