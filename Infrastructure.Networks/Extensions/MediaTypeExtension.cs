using Infrastructure.Networks.Enums;

namespace Infrastructure.Networks.Extensions;

/// <summary>
/// Расширение перечисления <see cref="MediaType"/>.
/// </summary>
public static class MediaTypeExtension
{
    #region Методы

    /// <summary>
    /// Преобразует значение типа медиа в его строковое представление.
    /// </summary>
    /// <param name="mediaType">Значение типа медиа, которое нужно преобразовать.</param>
    /// <returns>Строковое представление типа медиа.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Выбрасывается, если передано недопустимое значение типа медиа.</exception>

    public static string ToMediaTypeString(this MediaType mediaType)
    {
        return mediaType switch
        {
            MediaType.Json => "application/json",
            MediaType.Xml => "application/xml",
            MediaType.Html => "text/html",
            MediaType.Text => "text/plain",
            MediaType.FormUrlEncoded => "application/x-www-form-urlencoded",
            _ => throw new ArgumentOutOfRangeException(nameof(mediaType))
        };
    }

    #endregion
}
