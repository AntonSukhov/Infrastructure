using System.Text.Json;
using FluentAssertions;
using Infrastructure.Common.Services;
using Infrastructure.Common.Tests.JsonSerializationServiceTests.Models;
using Infrastructure.Common.Tests.TestData.JsonSerializationService.DeserializeAsync;

namespace Infrastructure.Common.Tests.JsonSerializationServiceTests;

/// <summary>
/// Тесты для проверки метода асинхронной десериализации строки формата JSON в объект.
/// </summary>
public class DeserializeAsyncTests
{
    #region Методы

    /// <summary>
    /// Тест проверки метода асинхронной сериализации объект в строку формата JSON для корректных входных параметров.
    /// </summary>
    /// <param name="employeeJson">Объект, который нужно сериализовать.</param>
    /// <param name="jsonSerializerOptions">Опции сериализации.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Асинхронная задача, представляющая результат выполнения теста.</returns>
    [Theory]
    [MemberData(nameof(ForCorrectInputParamsTestData.GetTestData),
                MemberType = typeof(ForCorrectInputParamsTestData))]
    public async Task ForCorrectInputParams(string employeeJson, JsonSerializerOptions? jsonSerializerOptions, CancellationToken cancellationToken)
    {
        var expected = await JsonSerializationService.DeserializeAsync<EmployeeModel>(employeeJson, jsonSerializerOptions, cancellationToken);

        expected.Should().NotBeNull()
                                .And
                                .Match<EmployeeModel>(p => p.Id > 0 &&
                                                           !string.IsNullOrWhiteSpace(p.Fio) &&
                                                           p.Gender == Gender.Male || p.Gender == Gender.Female &&
                                                           p.Birthdate != default &&
                                                           p.Salary >= 0m);
    }

    /// <summary>
    /// Тест проверки метода асинхронной сериализации объект в строку формата JSON для некорректных входных параметров.
    /// </summary>
    /// <param name="employeeJson">Объект, который нужно сериализовать.</param>
    /// <param name="jsonSerializerOptions">Опции сериализации.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Асинхронная задача, представляющая результат выполнения теста.</returns>
    [Theory]
    [MemberData(nameof(ForIncorrectInputParamsTestData.GetTestData),
                MemberType = typeof(ForIncorrectInputParamsTestData))]
    public async Task ForIncorrectInputParams(string employeeJson, JsonSerializerOptions? jsonSerializerOptions, CancellationToken cancellationToken)
    {
        var excepted = async () => await JsonSerializationService.DeserializeAsync<EmployeeModel>(employeeJson,
        jsonSerializerOptions, cancellationToken);

        var exception = await excepted.Should().ThrowAsync<Exception>();

        exception.Match(p => p.Any(p1 => p1 is ArgumentException || p1 is ArgumentNullException || p1 is Exception));
    }
    
    #endregion
}
