namespace Infrastructure.Common.Tests.JsonSerializationServiceTests.Models;

/// <summary>
/// Модель сотрудник.
/// </summary>
public class EmployeeModel
{
    #region Свойства

    public int Id { get; set; }
    public required string Fio { get; set; }
    public Gender Gender { get; set; }
    public DateTime Birthdate { get; set; }
    public decimal Salary { get; set; }
    public bool Dismissed { get; set; }

    #endregion
}

public enum Gender
{
    Male = 1,
    Female = 2
}
