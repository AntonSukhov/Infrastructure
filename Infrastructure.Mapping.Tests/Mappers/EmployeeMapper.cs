using Infrastructure.Mapping.Interfaces;
using Infrastructure.Mapping.Tests.Entities;
using Infrastructure.Mapping.Tests.Models;

namespace Infrastructure.Mapping.Tests.Mappers;

public class EmployeeMapper : IMapper<EmployeeEntity, EmployeeModel>
{
    public EmployeeModel Map(EmployeeEntity source)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));

        var employee = new EmployeeModel
        {
            Id = source.Id,
            Name = source.Name
        };

        return employee;
    }
}
