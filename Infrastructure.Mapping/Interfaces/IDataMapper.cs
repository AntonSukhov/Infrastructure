namespace Infrastructure.Mapping.Interfaces;

/// <summary>
/// Преобразователь объектов из одного типа в другой с использованием дополнительных данных.
/// </summary>
/// <typeparam name="TSource">Исходный тип объекта для преобразования.</typeparam>
/// <typeparam name="TDestination">Целевой тип объекта после преобразования.</typeparam>
/// <typeparam name="TData">Тип дополнительных данных, необходимых для выполнения маппинга.</typeparam>
public interface IDataMapper<TSource, TDestination, TData>
{
    /// <summary>
    /// Выполняет преобразование объекта из исходного типа в целевой с учётом дополнительных данных.
    /// </summary>
    /// <param name="source">Исходный объект, подлежащий преобразованию.</param>
    /// <param name="data">Коллекция дополнительных данных, необходимых для процесса маппинга.</param>
    /// <returns>Преобразованный объект целевого типа.</returns>
    TDestination Map(TSource source, IEnumerable<TData> data);
}
