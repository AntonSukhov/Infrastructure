namespace Infrastructure.Testing.TestCases;

/// <summary>
/// Тестовый сценарий с входными и выходными данными.
/// </summary>
/// <typeparam name="TIn">Тип входных данных.</typeparam>
/// <typeparam name="TOut">Тип выходных данных.</typeparam>
public class TestCase<TIn, TOut> : TestCaseInput<TIn>
{
    #region Свойства

    /// <summary>
    /// Получает или задает ожидаемые выходные данные сценария.
    /// </summary>
    public required TOut OutputData { get; set; }

    #endregion

}
