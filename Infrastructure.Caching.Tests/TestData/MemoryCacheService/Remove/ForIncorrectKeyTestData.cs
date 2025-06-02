namespace Infrastructure.Caching.Tests.TestData.MemoryCacheService.Remove;

/// <summary>
/// Тестовые данные проверки метода удаления значения из кэша для некорректного значения ключа.
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
