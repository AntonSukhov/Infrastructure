using Infrastructure.Testing.Tests.Entities;

namespace Infrastructure.Testing.Tests.Repositories;

/// <summary>
/// Реализация репозитория работы с отделом.
/// </summary>
public class DepartmentRepository : IDepartmentRepository
{
    /// <inheritdoc/>
    public DepartmentEntity? GetDepartmentById(int departmentId)
    {
         var departmentEntity = new DepartmentEntity
         {
             Id = departmentId,
             Name = $"Department {departmentId}"
         };

         return departmentEntity;
    }
}
