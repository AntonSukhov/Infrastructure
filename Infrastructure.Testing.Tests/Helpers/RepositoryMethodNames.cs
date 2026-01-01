using Infrastructure.Testing.Tests.Repositories;

namespace Infrastructure.Testing.Tests.Helpers;

/// <summary>
/// Помощник получения имён методов репозиториев.
/// </summary>
public static class RepositoryMethodNames
{
    // <summary>
    /// Имена методов для репозитория <see cref="IDepartmentRepository"/>.
    /// </summary>
    public static class DepartmentRepository
    {
        /// <summary>
        /// Получает имя метода <see cref="IDepartmentRepository.GetDepartmentById"/>.
        /// </summary>
        public static string GetDepartmentById => nameof(IDepartmentRepository.GetDepartmentById);
    }
}
