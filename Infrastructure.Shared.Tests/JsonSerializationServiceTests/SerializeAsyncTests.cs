using System.Text.Json;
using FluentAssertions;
using Infrastructure.Shared.Services;
using Infrastructure.Shared.Tests.JsonSerializationServiceTests.Models;
using Infrastructure.Shared.Tests.TestData.JsonSerializationService.SerializeAsync;

namespace Infrastructure.Shared.Tests.JsonSerializationServiceTests;

/// <summary>
/// Тесты для проверки метода асинхронной сериализации объект в строку формата JSON.
/// </summary>
public class SerializeAsyncTests
{
    #region Поля

    private readonly IJsonSerializationService _jsonSerializationService = new JsonSerializationService();

    #endregion

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
        var actual = await _jsonSerializationService.SerializeAsync(employee, jsonSerializerOptions, cancellationToken);

        actual.Should().NotBeNullOrWhiteSpace();

        var employeeActual = await _jsonSerializationService.DeserializeAsync<EmployeeModel>(actual, jsonSerializerOptions, cancellationToken);

        employeeActual.Should().NotBeNull()
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
        var action = await Assert.ThrowsAsync<ArgumentNullException>
        (
            async () => await _jsonSerializationService.SerializeAsync(employee, jsonSerializerOptions, cancellationToken)
        );

        action.Should().NotBeNull();                                             
    }
    #endregion
}
