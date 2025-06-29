namespace Infrastructure.Security.Tests.TestData.CryptographyService.GenerateSecureKey;

/// <summary>
/// Тестовые данные проверки метода генерации секретного ключа для некорректных входных параметров.
/// </summary>
public class ForIncorrectInputParamsTestData : TheoryData<int>
{
    #region Конструкторы

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public ForIncorrectInputParamsTestData()
    {
        Add(0);
        Add(int.MinValue);
        Add(int.MaxValue);
    }

    #endregion
}
