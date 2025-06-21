namespace Infrastructure.Networks.Enums;

/// <summary>
/// Тип медиа, который следует использовать для запроса содержимого.
/// </summary>
public enum MediaType
{
    /// <summary>
    /// Тип медиа, используемый для передачи данных в формате JSON (JavaScript Object Notation).
    /// </summary>
    Json,
    /// <summary>
    /// Тип медиа, используемый для передачи данных в формате XML (Extensible Markup Language).
    /// </summary>
    Xml,           
    /// <summary>
    /// Тип медиа, используемый для передачи данных в формате HTML (HyperText Markup Language).
    /// </summary>
    Html,
    /// <summary>
    /// Тип медиа, используемый для передачи данных в текстовом формате (plain text).
    /// </summary>
    Text,
    /// <summary>
    /// Тип медиа, используемый для передачи данных в формате URL-кодирования (application/x-www-form-urlencoded), обычно используется при отправке форм.
    /// </summary>
    FormUrlEncoded
}
