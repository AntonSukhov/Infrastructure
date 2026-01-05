using Infrastructure.Mapping.Interfaces;
using Infrastructure.Mapping.Tests.Comparers;
using Infrastructure.Mapping.Tests.Entities;
using Infrastructure.Mapping.Tests.Mappers;
using Infrastructure.Mapping.Tests.Models;

namespace Infrastructure.Mapping.Tests;

public class MapperFixture
{
    public IDataMapper<DepartmentEntity, DepartmentModel, EmployeeEntity> DepartmentMapper { get; }

    public IEqualityComparer<DepartmentModel?> DepartmentModelComparer { get; }

    public MapperFixture()
    {
        DepartmentMapper = new DepartmentMapper(new EmployeeMapper());
        DepartmentModelComparer = new DepartmentModelComparer (new EmployeeModelComparer());
    }
}
