namespace Infrastructure.Caching.Tests.TestData.MemoryCacheService.Remove;

/// <summary>
/// Тестовые данные проверки метода удаления значения из кэша для несуществующего ключа.
/// </summary>
public class ForNotExistedKeyTestData : TheoryData<string>
{
    #region Конструктор

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public ForNotExistedKeyTestData()
    {
        Add(Guid.NewGuid().ToString());
        Add(Guid.NewGuid().ToString());
        Add(Guid.NewGuid().ToString());
    }

    #endregion
}
