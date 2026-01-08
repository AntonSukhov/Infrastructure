namespace Infrastructure.Testing.Tests.Entities;

/// <summary>
/// Сущность отдел.
/// </summary>
public class DepartmentEntity
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
