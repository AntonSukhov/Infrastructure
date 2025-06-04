namespace Infrastructure.Caching.Tests.TestData.MemoryCacheService.Set;

/// <summary>
/// Тестовые данные проверки метода записи значения в кэш с корректными входными параметрами для 
/// уже существующего ключа.
/// </summary>
public class ForExistedKeyTestData : TheoryData<string, string?, DateTimeOffset>
{
    #region Конструктор

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public ForExistedKeyTestData()
    {
        var utcNow = DateTime.UtcNow;

        Add("71", "Значение 71", new DateTimeOffset(utcNow.AddMinutes(7)));
    }

    #endregion
}
