namespace Infrastructure.Mapping.Interfaces;

/// <summary>
/// Преобразователь объектов из одного типа в другой.
/// </summary>
/// <typeparam name="TSource">Исходный тип объекта для преобразования.</typeparam>
/// <typeparam name="TDestination">Целевой тип объекта после преобразования.</typeparam>
public interface IMapper<TSource, TDestination>
{
    /// <summary>
    /// Выполняет преобразование объекта из исходного типа в целевой.
    /// </summary>
    /// <param name="source">Исходный объект, подлежащий преобразованию.</param>
    /// <returns>Преобразованный объект целевого типа.</returns>
    TDestination Map(TSource source);
}
