namespace Infrastructure.Caching.Tests.TestData.MemoryCacheService.TryGetValue;

/// <summary>
/// Тестовые данные проверки метода попытки получения значения из кэша для некорректного значения ключа.
/// </summary>
public class ForIncorrectKeyTestData : TheoryData<string?>
{
    #region Конструктор

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public ForIncorrectKeyTestData()
    {
        Add(null);
        Add(string.Empty);
        Add(" ");
    }

    #endregion
}
