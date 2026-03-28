using System.Text.Json;
using Infrastructure.Shared.Services;
using Infrastructure.Shared.Tests.JsonSerializationServiceTests.Models;
using Infrastructure.Shared.Tests.TestData.JsonSerializationService.SerializeAsync;

namespace Infrastructure.Shared.Tests.JsonSerializationServiceTests;

/// <summary>
/// Тесты для проверки метода асинхронной сериализации объект в строку формата JSON.
/// </summary>
public class SerializeAsyncTests
{
    /// <summary>
    /// Тест проверки метода асинхронной сериализации объект в строку формата JSON для корректных входных параметров.
    /// </summary>
    /// <param name="employee">Объект, который нужно сериализовать.</param>
    /// <param name="jsonSerializerOptions">Опции сериализации.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Асинхронная задача, представляющая результат выполнения теста.</returns>
    [Theory]
    [MemberData(nameof(ForCorrectInputParamsTestData.GetTestData),
                MemberType = typeof(ForCorrectInputParamsTestData))]
    public async Task ForCorrectInputParams(EmployeeModel employee, JsonSerializerOptions? jsonSerializerOptions,
        CancellationToken cancellationToken)
    {
         // Arrange & Act:
        var serializeResult = await JsonSerializationService.SerializeAsync(employee, jsonSerializerOptions, cancellationToken);

        // Assert:
        Assert.False(string.IsNullOrWhiteSpace(serializeResult));

        var deserializeResult = await JsonSerializationService.DeserializeAsync<EmployeeModel>(serializeResult, jsonSerializerOptions,
            cancellationToken);

        Assert.NotNull(deserializeResult);
        Assert.Equal(deserializeResult.Id, employee.Id);
        Assert.Equal(deserializeResult.Fio, employee.Fio);
        Assert.Equal(deserializeResult.Gender, employee.Gender);
        Assert.Equal(deserializeResult.Birthdate, employee.Birthdate);
        Assert.Equal(deserializeResult.Salary, employee.Salary);
        Assert.Equal(deserializeResult.Dismissed, employee.Dismissed);
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
                MemberType = typeof(ForIncorrectInputParamsTestData))]
    public async Task ForIncorrectInputParams(EmployeeModel? employee, JsonSerializerOptions? jsonSerializerOptions,
        CancellationToken cancellationToken)
    {
         // Arrange & Act & Assert:
        var exception = await Assert.ThrowsAsync<ArgumentNullException>
        (
            async () => await JsonSerializationService.SerializeAsync(employee, jsonSerializerOptions, cancellationToken)
        );

        Assert.NotNull(exception);
    }
}
