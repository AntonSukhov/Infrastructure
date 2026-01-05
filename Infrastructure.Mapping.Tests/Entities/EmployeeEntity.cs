namespace Infrastructure.Mapping.Tests.Entities;

public class EmployeeEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
}
