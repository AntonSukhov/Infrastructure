namespace Infrastructure.Caching.Tests.TestData.MemoryCacheService.Set;

/// <summary>
/// Тестовые данные проверки метода записи значения в кэш с корректными входными параметрами.
/// </summary>
public class ForCorrectInputParamsTestData : TheoryData<string, string?, DateTimeOffset>
{
    #region Конструктор

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public ForCorrectInputParamsTestData()
    {
        var utcNow = DateTime.UtcNow;

        Add("1", "Значение 1", new DateTimeOffset(utcNow.AddMinutes(1)));
        Add("2", "Значение 2", new DateTimeOffset(utcNow.AddMinutes(5)));
        Add("3", "Значение 3", new DateTimeOffset(utcNow.AddMinutes(10)));
        Add("4", string.Empty, new DateTimeOffset(utcNow.AddMinutes(11)));
        Add("5", null, new DateTimeOffset(utcNow.AddMinutes(12)));
        Add("6", " ", new DateTimeOffset(utcNow.AddMinutes(12)));
    }

    #endregion
}
