using FluentAssertions;
using Infrastructure.Network.Enums;
using Infrastructure.Network.Extensions;
using Infrastructure.Network.Tests.TestData.MediaTypeExtension.ToMediaTypeString;

namespace Infrastructure.Network.Tests.MediaTypeExtensionTests;

/// <summary>
/// Тесты для проверки метода преобразования значение типа медиа в его строковое представление.
/// </summary>
public class ToMediaTypeStringTests
{
    #region Методы

    /// <summary>
    /// Тест проверки метода преобразования значения типа медиа в его строковое представление
    /// для существующих значений.
    /// </summary>
    /// <param name="mediaType">Значение типа медиа.</param>
    [Theory]
    [ClassData(typeof(ForExistedMediaTypeTestData))]
    public void ForExistedMediaType(MediaType mediaType)
    {
        var func = () => mediaType.ToMediaTypeString();

        func.Invoking(f => f()).Should().NotThrow()
                               .Which.Should().NotBeNullOrWhiteSpace();
    }

    /// <summary>
    /// Тест проверки метода преобразования значения типа медиа в его строковое представление
    /// для несуществующих значений.
    /// </summary>
    /// <param name="mediaType">Значение типа медиа.</param>
    [Theory]
    [ClassData(typeof(ForNotExistedMediaTypeTestData))]
    public void ForNotExistedMediaType(MediaType mediaType)
    {
        var func = () => mediaType.ToMediaTypeString();

        func.Invoking(f => f()).Should().Throw<ArgumentOutOfRangeException>();
    }

    #endregion
}
