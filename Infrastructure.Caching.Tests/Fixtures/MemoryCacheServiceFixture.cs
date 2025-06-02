using Infrastructure.Caching.Services;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Caching.Tests.Fixtures;

/// <summary>
/// Фикстура для тестирования методов сервиса работы с обобщенным кэшом в памяти.
/// </summary>
public class MemoryCacheServiceFixture
{
    #region Свойства

    /// <summary>
    /// Получает сервис работы с кэшем в памяти со строковыми ключами и значениями.
    /// </summary>
    public ICacheService<string, string> StringMemoryCacheService { get; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public MemoryCacheServiceFixture()
    {
        StringMemoryCacheService = new MemoryCacheService<string, string>(
        new MemoryCache(new MemoryCacheOptions()));

        var utcNow = DateTime.UtcNow;

        StringMemoryCacheService.Set("10", "Значение 10", new DateTimeOffset(utcNow.AddMinutes(5)));
        StringMemoryCacheService.Set("11", "Значение 11", new DateTimeOffset(utcNow.AddMinutes(10)));
        StringMemoryCacheService.Set("12", "Значение 12", new DateTimeOffset(utcNow.AddMinutes(15)));
    }

    #endregion
}
