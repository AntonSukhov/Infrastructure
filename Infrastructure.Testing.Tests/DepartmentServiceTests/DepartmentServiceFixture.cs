using Infrastructure.Testing.Tests.Comparers;
using Infrastructure.Testing.Tests.Repositories;
using Infrastructure.Testing.Tests.Services;
using Moq;

namespace Infrastructure.Testing.Tests.DepartmentServiceTests;

/// <summary>
/// Фикстура для тестирования сервиса работы с отделом.
/// </summary>
public class DepartmentServiceFixture
{
    /// <summary>
    /// Получает мок-объект репозитория работы с отделом.
    /// </summary>
    public Mock<IDepartmentRepository> DepartmentRepositoryMock { get; }

    /// <summary>
    /// Получает сервис работы с отделом.
    /// </summary>
    public IDepartmentService DepartmentService { get; }

    /// <summary>
    /// Получает компаратор для сравнения объектов <see cref="DepartmentModel"/>.
    /// </summary>
    public DepartmentModelComparer DepartmentModelComparer {get;}

    public DepartmentServiceFixture()
    {
        DepartmentRepositoryMock = new Mock<IDepartmentRepository>();
        DepartmentService = new DepartmentService(DepartmentRepositoryMock.Object);
        DepartmentModelComparer = new DepartmentModelComparer();
    }
}
