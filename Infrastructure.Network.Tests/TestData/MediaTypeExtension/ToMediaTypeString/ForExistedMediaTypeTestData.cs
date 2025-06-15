using Infrastructure.Network.Enums;

namespace Infrastructure.Network.Tests.TestData.MediaTypeExtension.ToMediaTypeString;

/// <summary>
/// Тестовые данные проверки метода преобразования значения типа медиа в его строковое представление
/// для существующих значений.
/// </summary>
public class ForExistedMediaTypeTestData : TheoryData<MediaType>
{
    #region Конструкторы

    public ForExistedMediaTypeTestData()
    {
        Add(MediaType.Json);
        Add(MediaType.Xml);
        Add(MediaType.Html);
        Add(MediaType.Text);
        Add(MediaType.FormUrlEncoded);
    }

    #endregion
}
