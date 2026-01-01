using Infrastructure.Testing.Tests.Models;

namespace Infrastructure.Testing.Tests.Services;

/// <summary>
/// Сервис работы с отделом.
/// </summary>
public interface IDepartmentService
{
    /// <summary>
    /// Получает отдел по его ИД.
    /// </summary>
    /// <param name="departmentId">ИД отдела.</param>
    /// <returns>Отдел.</returns>
    public DepartmentModel? GetDepartmentById(int departmentId);
}
