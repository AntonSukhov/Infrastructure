using Infrastructure.Mapping.Extensions;
using Infrastructure.Mapping.Interfaces;
using Infrastructure.Mapping.Tests.Entities;
using Infrastructure.Mapping.Tests.Models;

namespace Infrastructure.Mapping.Tests.Mappers;

public class DepartmentMapper : IDataMapper<DepartmentEntity, DepartmentModel, EmployeeEntity>
{
    private readonly IMapper<EmployeeEntity, EmployeeModel> _employeeMapper;

    public DepartmentMapper(IMapper<EmployeeEntity, EmployeeModel> employeeMapper)
    {
        ArgumentNullException.ThrowIfNull(employeeMapper, nameof(employeeMapper));

        _employeeMapper = employeeMapper;
    }

    public DepartmentModel Map(DepartmentEntity departmentEntity, 
        IEnumerable<EmployeeEntity> employeeEntities)
    {
        ArgumentNullException.ThrowIfNull(departmentEntity, nameof(departmentEntity));
        ArgumentNullException.ThrowIfNull(employeeEntities, nameof(employeeEntities));

        var employees = _employeeMapper.Map(employeeEntities.Where(
                            e => e.DepartmentId == departmentEntity.Id));

        var department = new DepartmentModel
        {
            Id = departmentEntity.Id,
            Name = departmentEntity.Name,
            Employees = employees
        };

        return department;
    }
}
