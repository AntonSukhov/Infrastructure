using System.Text.Json;
using Infrastructure.Common.Tests.JsonSerializationServiceTests.Models;

namespace Infrastructure.Common.Tests.TestData.JsonSerializationService.SerializeAsync;

/// <summary>
/// Тестовые данные проверки метода асинхронной сериализации объект в строку формата JSON.
/// </summary>
public class ForCorrectInputParamsTestData : TheoryData<EmployeeModel, JsonSerializerOptions?, CancellationToken>
{
    #region Конструктор

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public ForCorrectInputParamsTestData()
    {
        var employee = new EmployeeModel
        {
            Id = 1,
            Fio = "Иванов Иван Иванович",
            Gender = Gender.Male,
            Birthdate = new DateTime(1974, 10, 24),
            Salary = 150000m
        };

        var employeeWithEmptyFio = new EmployeeModel
        {
            Id = 2,
            Fio = string.Empty,
            Gender = Gender.Female,
            Birthdate = new DateTime(1990, 5, 15),
            Salary = 75000m
        };

        var employeeWithZeroSalary = new EmployeeModel
        {
            Id = 3,
            Fio = "Петрова Анна Сергеевна",
            Gender = Gender.Female,
            Birthdate = new DateTime(1985, 3, 10),
            Salary = 0m
        };

        var employeeWithMaxSalary = new EmployeeModel
        {
            Id = 4,
            Fio = "Сидоров Алексей Викторович",
            Gender = Gender.Male,
            Birthdate = new DateTime(1980, 12, 1),
            Salary = decimal.MaxValue
        };

        var dismissedEmployee = new EmployeeModel
        {
            Id = 5,
            Fio = "Григорьев Игорь Николаевич",
            Gender = Gender.Male,
            Birthdate = new DateTime(1995, 8, 20),
            Salary = 60000m,
            Dismissed = true
        };

        var employeeWithUndefinedGender = new EmployeeModel
        {
            Id = 6,
            Fio = "Лебедева Ольга Васильевна",
            Gender = default,
            Birthdate = new DateTime(1992, 4, 12),
            Salary = 80000m
        };

        Add(employee, JsonSerializerOptions.Default, default);
        Add(employee, null, default);
        Add(employeeWithEmptyFio, JsonSerializerOptions.Default, default);
        Add(employeeWithZeroSalary, JsonSerializerOptions.Default, default);
        Add(employeeWithMaxSalary, JsonSerializerOptions.Default, default);
        Add(dismissedEmployee, JsonSerializerOptions.Default, default);
        Add(employeeWithUndefinedGender, JsonSerializerOptions.Default, default);
    }

    #endregion
}
