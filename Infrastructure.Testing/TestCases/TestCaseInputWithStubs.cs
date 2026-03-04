using Infrastructure.Testing.Common;

namespace Infrastructure.Testing.TestCases;

/// <summary>
/// Тестовый сценарий с входными данными и данными для заглушек. 
/// </summary>
/// <typeparam name="TIn">Тип входных данных.</typeparam>
public class TestCaseInputWithStubs<TIn>: TestCaseInput<TIn>
{
    /// <summary>
    /// Получает или задает словарь выходных данных для заглушек.
    /// </summary>
    /// <remarks>
    /// Словарь состоит из пар «ключ-значение»:
    /// <list type="table">
    ///   <item>
    ///     <term>Ключ</term>
    ///     <description>Экземпляр класса <see cref="StubOutputKey"/>.</description>
    ///   </item>
    ///   <item>
    ///     <term>Значение</term>
    ///     <description>Экземпляр класса <see cref="StubOutput"/> с выходными данными для заглушек.</description>
    ///   </item>
    /// </list>
    /// </remarks>
    public required IDictionary<StubOutputKey, StubOutput> StubOutputs { get; set; } 

}
