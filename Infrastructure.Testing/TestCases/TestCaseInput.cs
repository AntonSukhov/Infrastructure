using Infrastructure.Testing.Common;

namespace Infrastructure.Testing.TestCases;

/// <summary>
/// Тестовый сценарий с входными данными.
/// </summary>
/// <typeparam name="TIn">Тип входных данных.</typeparam>
public class TestCaseInput<TIn>: TestCaseBase
{
    /// <summary>
    /// Получает или задает входные данные сценария.
    /// </summary>
    public required TIn InputData { get; set; }

}

