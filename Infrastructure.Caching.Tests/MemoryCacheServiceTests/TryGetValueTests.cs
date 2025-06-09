using FluentAssertions;
using Infrastructure.Caching.Tests.Fixtures;
using Infrastructure.Caching.Tests.TestData.MemoryCacheService.TryGetValue;

namespace Infrastructure.Caching.Tests.MemoryCacheServiceTests;

/// <summary>
/// Тесты для проверки метода попытки получения значения из кэша по ключу.
/// </summary>
public class TryGetValueTests : IClassFixture<MemoryCacheServiceFixture>
{
    #region Поля

    private readonly MemoryCacheServiceFixture _memoryCacheServiceFixture;

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    /// <param name="memoryCacheServiceFixture">Фикстура для тестирования методов сервиса работы с
    /// обобщенным кэшом в памяти.</param>
    public TryGetValueTests(MemoryCacheServiceFixture memoryCacheServiceFixture)
    {
        _memoryCacheServiceFixture = memoryCacheServiceFixture;
    }

    #endregion

    #region Методы

    /// <summary>
    /// Тест проверки метода попытки получения значения из кэша для существующего ключа.
    /// </summary>
    /// <param name="key">Значение ключа.</param>
    [Theory]
    [ClassData(typeof(ForExistedKeyTestData))]
    public void ForExistedKeyTest(string key)
    {
        var actualPr = _memoryCacheServiceFixture.StringMemoryCacheService.TryGetValue(key, out var actualValue);

        actualPr.Should().BeTrue();
        actualValue.Should().NotBeNullOrWhiteSpace();
    }

    /// <summary>
    /// Тест проверки метода попытки получения значения из кэша для несуществующего ключа.
    /// </summary>
    /// <param name="key">Значение ключа.</param>
    [Theory]
    [ClassData(typeof(ForNotExistedKeyTestData))]
    public void ForNotExistedKeyTest(string key)
    {
        var actualPr = _memoryCacheServiceFixture.StringMemoryCacheService.TryGetValue(key, out var actualValue);

        actualPr.Should().BeFalse();
        actualValue.Should().BeNull();
    }

    /// <summary>
    /// Тест проверки метода попытки получения значения из кэша для несуществующего ключа.
    /// </summary>
    /// <param name="key">Значение ключа.</param>
    [Theory]
    [ClassData(typeof(ForIncorrectKeyTestData))]
    public void ForIncorrectKeyTest(string key)
    {
        var action = () => _memoryCacheServiceFixture.StringMemoryCacheService.TryGetValue(key, out var actualValue);

        var exception = action.Should().Throw<Exception>().Which;

        if (exception is not (ArgumentNullException or ArgumentException))
        {
            throw new Exception($"Ожидалось {nameof(ArgumentNullException)} или {nameof(ArgumentException)}, но возникло другое исключение.");
        }
    }

    #endregion
}
