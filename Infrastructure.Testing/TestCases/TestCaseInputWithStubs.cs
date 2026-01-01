using Infrastructure.Testing.Common;

namespace Infrastructure.Testing.TestCases;

/// <summary>
/// Тестовый сценарий с входными данными и данными для заглушек. 
/// </summary>
/// <typeparam name="TIn">Тип входных данных.</typeparam>
public class TestCaseInputWithStubs<TIn>: TestCaseInput<TIn>
{
    #region Свойства

    /// <summary>
    /// Получает или задает словарь выходных данных для заглушек.
    /// </summary>
    /// <remarks>
    /// Ключ — составной (имя тестируемого метода, порядковый номер данных в словаре),
    /// значение — экземпляр класса <see cref="StubOutputs"/> с выходными данными для заглушек.
    /// </remarks>
    public required IDictionary<(string MethodName, int SequenceNumber), StubOutput> StubOutputs { get; set; } 

    #endregion
}
