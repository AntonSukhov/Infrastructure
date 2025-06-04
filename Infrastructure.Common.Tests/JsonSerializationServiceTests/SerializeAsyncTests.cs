using System.Text.Json;
using FluentAssertions;
using Infrastructure.Common.Services;
using Infrastructure.Common.Tests.JsonSerializationServiceTests.Models;
using Infrastructure.Common.Tests.TestData.JsonSerializationService.SerializeAsync;

namespace Infrastructure.Common.Tests.JsonSerializationServiceTests;

/// <summary>
/// Тесты для проверки метода асинхронной сериализации объект в строку формата JSON.
/// </summary>
public class SerializeAsyncTests
{
    #region Методы

    /// <summary>
    /// 
    /// </summary>
    /// <param name="employee"></param>
    /// <param name="jsonSerializerOptions"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Theory]
    [ClassData(typeof(ForCorrectInputParamsTestData))]
    public async Task ForCorrectInputParams(EmployeeModel employee, JsonSerializerOptions? jsonSerializerOptions, CancellationToken cancellationToken)
    {
        var expected = await JsonSerializationService.SerializeAsync(employee, jsonSerializerOptions, cancellationToken);

        expected.Should().NotBeNullOrWhiteSpace();

        var employeeExpected = await JsonSerializationService.DeserializeAsync<EmployeeModel>(expected, jsonSerializerOptions, cancellationToken);

        employeeExpected.Should().NotBeNull()
                                .And
                                .Match<EmployeeModel>(p => p.Id == employee.Id &&
                                                           p.Fio == employee.Fio &&
                                                           p.Gender == employee.Gender &&
                                                           p.Birthdate == employee.Birthdate &&
                                                           p.Salary == employee.Salary &&
                                                           p.Dismissed == employee.Dismissed);                                             
    }
    #endregion
}
