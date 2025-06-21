using Infrastructure.Networks.Enums;

namespace Infrastructure.Networks.Tests.TestData.MediaTypeExtension.ToMediaTypeString;

/// <summary>
/// Тестовые данные проверки метода преобразования значения типа медиа в его строковое представление
/// для несуществующих значений.
/// </summary>
public class ForNotExistedMediaTypeTestData : TheoryData<MediaType>
{
    #region Конструкторы

    public ForNotExistedMediaTypeTestData()
    {
        var maxValue = int.MaxValue;

        Add((MediaType)maxValue);
        Add((MediaType)maxValue - 1);
        Add((MediaType)maxValue - 10);
    }

    #endregion
}
