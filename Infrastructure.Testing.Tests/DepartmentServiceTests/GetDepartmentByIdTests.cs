using Infrastructure.Testing.Common;
using Infrastructure.Testing.TestCases;
using Infrastructure.Testing.Tests.Entities;
using Infrastructure.Testing.Tests.Helpers;
using Infrastructure.Testing.Tests.Models;
using Infrastructure.Testing.XUnit;
using Moq;

namespace Infrastructure.Testing.Tests.DepartmentServiceTests;

/// <summary>
/// Набор тестов для проверки метода <see cref="IDepartmentService.GetDepartmentById(int)"/>.
/// </summary>
public class GetDepartmentByIdTests : BaseTest<DepartmentServiceFixture>
{
    public GetDepartmentByIdTests(DepartmentServiceFixture departmentServiceFixture)
        : base(departmentServiceFixture)
    {
    }

    /// <summary>
    /// Тест успешного получения существующего отдела по идентификатору.
    /// </summary>
    /// <param name="testCase">Тестовый сценарий, содержащий входные данные, ожидаемый результат
    /// и заглушки для имитации зависимостей.</param>
    [Theory]
    [MemberData(nameof(ExistDepartment))]
    public void ForExistDepartment(TestCaseWithStubs<int, DepartmentModel> testCase)
    {
        // Arrange:
        var stubOutput = testCase.StubOutputs[
            (MethodName: RepositoryMethodNames.DepartmentRepository.GetDepartmentById,
             SequenceNumber: 1)];

        _fixture.DepartmentRepositoryMock
            .Setup(s => s.GetDepartmentById(It.IsAny<int>()))
            .Returns(() => stubOutput.GetOutputData<DepartmentEntity>());

        // Act:
        var result = _fixture.DepartmentService.GetDepartmentById(testCase.InputData);

        // Assert:
        Assert.Equal(testCase.OutputData, result, _fixture.DepartmentModelComparer);
    }

    /// <summary>
    /// Тест проверки метода в случае отсутствия отдела в источнике данных.
    /// </summary>
    /// <param name="testCase">Тестовый сценарий, содержащий входные данные для отсутствия отдела в источнике данных.</param>
    [Theory]
    [MemberData(nameof(NoExistDepartment))]
    public void ForNoExistDepartment(TestCase<int, DepartmentModel?> testCase)
    {
        // Arrange:
        _fixture.DepartmentRepositoryMock
            .Setup(s => s.GetDepartmentById(It.IsAny<int>()))
            .Returns(() => default);

        // Act:
        var result = _fixture.DepartmentService.GetDepartmentById(testCase.InputData);

        // Assert:
        Assert.Null(result);
    }

    /// <summary>
    /// Получает тестовые данные для сценариев успешного получения существующего отдела.
    /// </summary>
    /// <remarks>
    /// Каждый сценарий включает:
    /// <list type="bullet">
    ///   <item><description>Входной идентификатор отдела;</description></item>
    ///   <item><description>Ожидаемый объект <see cref="DepartmentModel"/>;</description></item>
    ///   <item><description>Заглушку для имитации ответа репозитория.</description></item>
    /// </list>
    /// </remarks>
    public static TheoryData<TestCaseWithStubs<int, DepartmentModel>> ExistDepartment =>
    [
        new TestCaseWithStubs<int, DepartmentModel>
        {
            ScenarioNumber = 1,
            InputData = 15,
            OutputData = new DepartmentModel 
            {
                Id = 15,
                Name = "Department 15"
            },
            Description = "Получение данных отдела, который присутствует в хранилище.",
            StubOutputs = new Dictionary<(string, int), StubOutput>
            {
                {
                    (RepositoryMethodNames.DepartmentRepository.GetDepartmentById, 1),
                    new StubOutput
                    {
                        OutputData = new DepartmentEntity
                        {
                            Id = 15,
                            Name = "Department 15"
                        },
                        ExpectedType = typeof(DepartmentEntity)
                    }
                }
            }
        }
    ];

    /// <summary>
    /// Получает тестовые данные для сценариев отсутствия данных отдела в хранилище.
    /// </summary>
    /// <remarks>
    /// Каждый сценарий включает:
    /// <list type="bullet">
    ///   <item><description>Входной идентификатор отдела;</description></item>
    ///   <item><description>Ожидаемый объект <see cref="DepartmentModel"/> равен <c>Null</c>;</description></item>
    /// </list>
    /// </remarks>
    public static TheoryData<TestCase<int, DepartmentModel?>>  NoExistDepartment =>
    [
        new TestCase<int, DepartmentModel?>
        {
            ScenarioNumber = 1,
            InputData = int.MaxValue,
            OutputData = default,
            Description = "Отсутствие данных отдела в хранилище."
        }
    ];
}
