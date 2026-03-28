using Infrastructure.Networks.Enums;
using Infrastructure.Networks.Extensions;
using Infrastructure.Networks.Tests.TestData.MediaTypeExtension.ToMediaTypeString;

namespace Infrastructure.Networks.Tests.MediaTypeExtensionTests;

/// <summary>
/// Тесты для проверки метода преобразования значение типа медиа в его строковое представление.
/// </summary>
public class ToMediaTypeStringTests
{
    /// <summary>
    /// Тест проверки метода преобразования значения типа медиа в его строковое представление
    /// для существующих значений.
    /// </summary>
    /// <param name="mediaType">Значение типа медиа.</param>
    [Theory]
    [ClassData(typeof(ForExistedMediaTypeTestData))]
    public void ForExistedMediaType(MediaType mediaType)
    {
        // Arrange
        var func = () => mediaType.ToMediaTypeString();

        // Act 
        var result = func();

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
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
        // Arrange
        var func = () => mediaType.ToMediaTypeString();

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(func);
    }
}
