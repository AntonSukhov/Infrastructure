namespace Infrastructure.Testing.Tests.Models;

/// <summary>
/// Модель отдел.
/// </summary>
public class DepartmentModel
{
    /// <summary>
    /// Получает или задает ИД отдела.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Получает или задает название отдела.
    /// </summary>
    public required string Name { get; set; }

}
