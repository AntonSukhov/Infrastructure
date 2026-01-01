namespace Infrastructure.Testing.TestCases;

/// <summary>
/// Тестовый сценарий с входными и выходными данными, и данными для заглушек. 
/// </summary>
/// <typeparam name="TIn">Тип входных данных.</typeparam>
/// <typeparam name="TOut">Тип выходных данных.</typeparam>
public class TestCaseWithStubs<TIn, TOut> : TestCaseInputWithStubs<TIn>
{
    #region Свойства

    /// <summary>
    /// Получает или задает ожидаемые выходные данные теста.
    /// </summary>
    public required TOut OutputData { get; set; }

    #endregion

}
