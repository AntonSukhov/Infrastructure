using AutoMapper;
using Infrastructure.Mapping.Interfaces;

namespace Infrastructure.Mapping.AutoMapper;

/// <summary>
/// Реализация преобразователя объектов из одного типа в другой.
/// </summary>
/// <typeparam name="TSource"></typeparam>
/// <typeparam name="TDestination"></typeparam>
public class Mapper<TSource, TDestination> : IMapper<TSource, TDestination>
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Инициализирует экземпляр типа <see cref="Mapper{TSource, TDestination}"/>.
    /// </summary>
    /// <param name="mapper"></param>
    public Mapper(IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(mapper, nameof(mapper));

        _mapper = mapper;
    }

    /// <inheritdoc/>
    public TDestination Map(TSource source) => _mapper.Map<TDestination>(source);
}
