using Infrastructure.Testing.Tests.Models;

namespace Infrastructure.Testing.Tests.Comparers;

/// <summary>
/// Компаратор для сравнения объектов <see cref="DepartmentModel"/>.
/// </summary>
public class DepartmentModelComparer : IEqualityComparer<DepartmentModel?>
{
    /// <summary>
    /// Определяет равенство двух объектов <see cref="DepartmentModel"/>.
    /// </summary>
    /// <param name="department1">Первый объект для сравнения.</param>
    /// <param name="department2">Второй объект для сравнения.</param>
    /// <returns>True, если объекты равны; иначе false.</returns>
    public bool Equals(DepartmentModel? department1, DepartmentModel? department2)
    {
        if (department1 is null && department2 is null)
            return true;
        
        if (department1 is null || department2 is null)
            return false;
        
        return department1.Id == department2.Id &&
               department1.Name == department2.Name;
    }

    /// <summary>
    /// Вычисляет хэш‑код для объекта <see cref="DepartmentModel"/>.
    /// </summary>
    /// <param name="department">Объект для вычисления хэш‑кода.</param>
    /// <returns>Хэш‑код объекта.</returns>
    public int GetHashCode(DepartmentModel department)
    {
        if (department is null)
            return 0;

        return HashCode.Combine(department.Id, department.Name);
    }
}

