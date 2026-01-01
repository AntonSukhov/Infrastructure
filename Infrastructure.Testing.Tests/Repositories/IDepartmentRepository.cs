using Infrastructure.Testing.Tests.Entities;

namespace Infrastructure.Testing.Tests.Repositories;

/// <summary>
/// Репозиторий работы с отделом.
/// </summary>
public interface IDepartmentRepository
{
    /// <summary>
    /// Получает отдел по его ИД.
    /// </summary>
    /// <param name="departmentId">ИД отдела.</param>
    /// <returns>Отдел.</returns>
    public DepartmentEntity? GetDepartmentById(int departmentId);
}
