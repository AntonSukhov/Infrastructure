namespace Infrastructure.Mapping.Tests.Models;

public class DepartmentModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public IReadOnlyCollection<EmployeeModel> Employees { get; set; } = [];
}
