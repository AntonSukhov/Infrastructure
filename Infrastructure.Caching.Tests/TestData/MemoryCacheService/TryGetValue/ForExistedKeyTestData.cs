namespace Infrastructure.Caching.Tests.TestData.MemoryCacheService.TryGetValue;

/// <summary>
/// Тестовые данные проверки метода попытки получения значения из кэша для существующего ключа.
/// </summary>
public class ForExistedKeyTestData : TheoryData<string>
{
    #region Конструктор

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public ForExistedKeyTestData()
    {
        Add("10");
        Add("11");
        Add("12");
    }

    #endregion
}

