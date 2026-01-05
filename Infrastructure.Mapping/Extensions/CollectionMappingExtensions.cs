using Infrastructure.Mapping.Interfaces;

namespace Infrastructure.Mapping.Extensions;

/// <summary>
/// Расширения интерфейса <see cref="IMapper{TSource, TDestination}"/> 
/// для выполнения маппинга коллекций объектов.
/// </summary>
public static class CollectionMappingExtensions
{
    /// <summary>
    /// Преобразует элементы исходной коллекции в новый тип с помощью указанного маппера 
    /// и возвращает результат в виде коллекции только для чтения.
    /// </summary>
    /// <typeparam name="TSource">Тип исходных объектов, которые требуется преобразовать.</typeparam>
    /// <typeparam name="TDestination">Целевой тип объектов после преобразования.</typeparam>
    /// <param name="mapper">Экземпляр маппера, ответственный за преобразование объекта типа 
    /// <typeparamref name="TSource"/> в объект типа <typeparamref name="TDestination"/>.</param>
    /// <param name="sources">Исходная коллекция объектов типа <typeparamref name="TSource"/>,
    /// которые требуется преобразовать.</param>
    /// <returns>Коллекция только для чтения, содержащая преобразованные объекты целевого типа.</returns>
    public static IReadOnlyCollection<TDestination> Map<TSource, TDestination> (
        this IMapper<TSource, TDestination> mapper, 
        IEnumerable<TSource> sources)
    {
        ArgumentNullException.ThrowIfNull(mapper, nameof(mapper));
        ArgumentNullException.ThrowIfNull(sources, nameof(sources));

        var destinations = sources.Select(mapper.Map)
                                  .ToList();

        return destinations;
    }

    /// <summary>
    /// Преобразует элементы исходной коллекции в новый тип с помощью указанного маппера,
    /// используя дополнительные данные для преобразования, и возвращает результат
    /// в виде коллекции только для чтения.
    /// </summary>
    /// <typeparam name="TSource">Тип исходных объектов, которые требуется преобразовать.</typeparam>
    /// <typeparam name="TDestination">Целевой тип объектов после преобразования.</typeparam>
    /// <typeparam name="TData">Тип дополнительных данных, используемых при преобразовании объектов.</typeparam>
    /// <param name="mapper">Экземпляр маппера, ответственный за преобразование объекта типа
    /// <typeparamref name="TSource"/> в объект типа <typeparamref name="TDestination"/>
    /// с использованием данных типа <typeparamref name="TData"/>.</param>
    /// <param name="sources">Исходная коллекция объектов типа <typeparamref name="TSource"/>,
    /// которые требуется преобразовать.</param>
    /// <param name="data">Коллекция дополнительных данных типа <typeparamref name="TData"/>,
    /// используемых при преобразовании каждого объекта из <paramref name="sources"/>.</param>
    /// <returns>Коллекция только для чтения, содержащая преобразованные объекты целевого типа.</returns>
    public static IReadOnlyCollection<TDestination> Map<TSource, TDestination, TData> (
        this IDataMapper<TSource, TDestination, TData> mapper, 
        IEnumerable<TSource> sources, IEnumerable<TData> data)
    {
        ArgumentNullException.ThrowIfNull(mapper, nameof(mapper));
        ArgumentNullException.ThrowIfNull(sources, nameof(sources));

        var destinations = sources.Select(s => mapper.Map(s, data))
                                  .ToList();

        return destinations;
    }
}
