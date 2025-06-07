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
    /// Тест проверки метода асинхронной сериализации объект в строку формата JSON для корректных входных параметров.
    /// </summary>
    /// <param name="employee">Объект, который нужно сериализовать.</param>
    /// <param name="jsonSerializerOptions">Опции сериализации.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Асинхронная задача, представляющая результат выполнения теста.</returns>
    [Theory]
    [MemberData(nameof(ForCorrectInputParamsTestData.GetTestData),
                MemberType =typeof(ForCorrectInputParamsTestData))]
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
    
    /// <summary>
    /// Тест проверки метода асинхронной сериализации объект в строку формата JSON для некорректных входных параметров.
    /// </summary>
    /// <param name="employee">Объект, который нужно сериализовать.</param>
    /// <param name="jsonSerializerOptions">Опции сериализации.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Асинхронная задача, представляющая результат выполнения теста.</returns>
    [Theory]
    [MemberData(nameof(ForIncorrectInputParamsTestData.GetTestData),
                MemberType =typeof(ForIncorrectInputParamsTestData))]
    public async Task ForIncorrectInputParams(EmployeeModel? employee, JsonSerializerOptions? jsonSerializerOptions, CancellationToken cancellationToken)
    {
        var expected = await Assert.ThrowsAsync<ArgumentNullException>
        (
            async () => await JsonSerializationService.SerializeAsync(employee, jsonSerializerOptions, cancellationToken)
        );

        expected.Should().NotBeNull();                                             
    }
    #endregion
}
