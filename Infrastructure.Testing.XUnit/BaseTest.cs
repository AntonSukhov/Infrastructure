using System;
using Xunit;

namespace Infrastructure.Testing.XUnit;

/// <summary>
/// Базовый тест.
/// </summary>
/// <typeparam name="TFixture">Тип данных фикстуры.</typeparam>
public class BaseTest<TFixture> : IClassFixture<TFixture> where TFixture : class
{
    /// <summary>
    /// Экземпляр фикстуры.
    /// </summary>
    protected readonly TFixture _fixture;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="BaseTest{TFixture}"/>.
    /// </summary>
    /// <param name="fixture">Экземпляр фикстуры.</param>
    /// <exception cref="ArgumentNullException"/>
    public BaseTest(TFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture, nameof(fixture));

        _fixture = fixture;
    }

}
