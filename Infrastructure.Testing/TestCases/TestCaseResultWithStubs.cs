using Infrastructure.Testing.Common;

namespace Infrastructure.Testing.TestCases;

/// <summary>
///Тестовый сценарий для методов без входных параметров,
///с заглушками и ожидаемым выходным результатом.
///</summary>
/// <typeparam name="TOut">Тип выходных данных.</typeparam>
public class TestCaseResultWithStubs<TOut>: TestCaseResult<TOut>
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
