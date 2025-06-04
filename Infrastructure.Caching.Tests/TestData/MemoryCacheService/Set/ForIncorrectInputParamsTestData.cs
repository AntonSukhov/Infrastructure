namespace Infrastructure.Caching.Tests.TestData.MemoryCacheService.Set;

/// <summary>
/// Тестовые данные проверки метода записи значения в кэш с некорректными входными параметрами.
/// </summary>
public class ForIncorrectInputParamsTestData : TheoryData<string?, string?, DateTimeOffset>
{
    #region Конструктор

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public ForIncorrectInputParamsTestData()
    {
        var utcNow = DateTime.UtcNow;

        Add(null, "Значение 1", new DateTimeOffset(utcNow.AddMinutes(4)));
        Add(string.Empty, "Значение 2", new DateTimeOffset(utcNow.AddMinutes(5)));
        Add(" ", "Значение 3", new DateTimeOffset(utcNow.AddMinutes(10)));
    }

    #endregion
}
