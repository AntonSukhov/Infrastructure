using FluentAssertions;
using Infrastructure.Caching.Services;
using Infrastructure.Caching.Tests.TestData.MemoryCacheService.Set;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Caching.Tests.MemoryCacheServiceTests;

/// <summary>
/// Тесты для проверки метода записи значения в кэш.
/// </summary>
public class SetTests
{
    #region Поля

    private readonly MemoryCacheService<string, string> _stringMemoryCacheService;

    #endregion

    #region Конструктор

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public SetTests()
    {
        _stringMemoryCacheService = new MemoryCacheService<string, string>(new MemoryCache(new MemoryCacheOptions()));
    }

    /// <summary>
    /// Тест проверки метода записи значения в кэш для корректных входных параметров.
    /// </summary>
    /// <param name="key">Значение ключа.</param>
    /// <param name="value">Сохраняемое значение.</param>
    /// <param name="absoluteExpiration">Момент времени, в который истекает срок действия записи в кэше.</param>
    [Theory]
    [ClassData(typeof(ForCorrectInputParamsTestData))]
    public void ForCorrectInputParams(string key, string value, DateTimeOffset absoluteExpiration)
    {
        _stringMemoryCacheService.Set(key, value, absoluteExpiration);

        var actualPr = _stringMemoryCacheService.TryGetValue(key, out var expectedValue);

        var (Pr, Key, Value) = (actualPr, key, expectedValue);

        Pr.Should().BeTrue();
        Key.Should().Be(key);
        Value.Should().Be(value);
    }

    /// <summary>
    /// Тест проверки метода записи значения в кэш для некорректных входных параметров.
    /// </summary>
    /// <param name="key">Значение ключа.</param>
    /// <param name="value">Сохраняемое значение.</param>
    /// <param name="absoluteExpiration">Момент времени, в который истекает срок действия записи в кэше.</param>
    [Theory]
    [ClassData(typeof(ForIncorrectInputParamsTestData))]
    public void ForIncorrectInputParams(string key, string value, DateTimeOffset absoluteExpiration)
    {
        var action = () => _stringMemoryCacheService.Set(key, value, absoluteExpiration);

        var exception = action.Should().Throw<Exception>().Which;

        if (exception is not (ArgumentNullException or ArgumentException))
        {
            throw new Exception($"Ожидалось {nameof(ArgumentNullException)} или {nameof(ArgumentException)}, но возникло другое исключение.");
        }
    }

    /// <summary>
    /// Тест проверки метода записи значения в кэш с корректными входными параметрами для 
    /// уже существующего ключа.
    /// </summary>
    /// <param name="key">Значение ключа.</param>
    /// <param name="value">Сохраняемое значение.</param>
    /// <param name="absoluteExpiration">Момент времени, в который истекает срок действия записи в кэше.</param>
    [Theory]
    [ClassData(typeof(ForExistedKeyTestData))]
    public void ForExistedKey(string key, string value, DateTimeOffset absoluteExpiration)
    {
        var action = () => _stringMemoryCacheService.Set(key, value, absoluteExpiration);

        action.Should().NotThrow();

        var expectedValue = "New value";

        var actionForDuplicate = () => _stringMemoryCacheService.Set(key, expectedValue, absoluteExpiration);

        actionForDuplicate.Should().NotThrow();

        var actualPr = _stringMemoryCacheService.TryGetValue(key, out var actualValue);

        actualPr.Should().BeTrue();
        actualValue.Should().Be(expectedValue);
        
    }

    #endregion
}
