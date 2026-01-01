using Infrastructure.Testing.Tests.Models;
using Infrastructure.Testing.Tests.Repositories;

namespace Infrastructure.Testing.Tests.Services;

/// <summary>
/// Реализация сервиса работы с отделом.
/// </summary>
public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        ArgumentNullException.ThrowIfNull(departmentRepository, nameof(departmentRepository));

        _departmentRepository = departmentRepository;
    }

    /// <inheritdoc/>
    public DepartmentModel? GetDepartmentById(int departmentId)
    {
        var departmentEntity = _departmentRepository.GetDepartmentById(departmentId);

        if(departmentEntity is null)
          return null;

        var departmentModel = new DepartmentModel
        {
            Id = departmentEntity.Id,
            Name = departmentEntity.Name
        };

        return departmentModel;
    }
}
