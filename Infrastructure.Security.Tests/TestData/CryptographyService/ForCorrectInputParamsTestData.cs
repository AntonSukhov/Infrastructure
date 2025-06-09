using Xunit;

namespace Infrastructure.Security.Tests.TestData.CryptographyService;

/// <summary>
/// Тестовые данные проверки метода генерации секретного ключа для корректных входных параметров.
/// </summary>
public class ForCorrectInputParamsTestData : TheoryData<int>
{
    #region Конструкторы

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public ForCorrectInputParamsTestData()
    {
        Add(16);
        Add(32);
        Add(64);
    }

    #endregion
}
