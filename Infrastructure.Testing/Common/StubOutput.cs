namespace Infrastructure.Testing.Common;

/// <summary>
///  Выходные данные для заглушки.
/// </summary>
public class StubOutput
{
    /// <summary>
    /// Получает или задает выходные данные для заглушки.
    /// </summary>
    public required object? OutputData { get; set; }

    /// <summary>
    /// Получает или задает ожидаемых тип выходных данных для заглушки.
    /// </summary>
    public required Type ExpectedType { get; set; }

    /// <summary>
    /// Получает выходные данные, конвертированные в указанный тип.
    /// </summary>
    /// <typeparam name="T">Целевой тип данных для приведения.</typeparam>
    /// <returns>
    /// Экземпляр типа <typeparamref name="T"/>, если <see cref="OutputData"/> имеет точно такой же тип.
    /// </returns>
    /// <exception cref="InvalidCastException">Исключение, возникающее, когда фактический тип <see cref="OutputData"/>
    /// не совпадает с <typeparamref name="T"/>.</exception>
    public T? GetOutputData<T>()
    {
       if (typeof(T) != ExpectedType)
        {
            throw new InvalidCastException(
                $"Невозможно привести значение типа '{ExpectedType.Name}' к запрошенному типу '{typeof(T).Name}'." 
            );
        }

        if (OutputData == null)
        {
            if (ExpectedType.IsValueType && !IsNullableType(ExpectedType))
            {
                throw new InvalidCastException(
                    $"Невозможно привести null к типу '{ExpectedType.Name}', так как он не допускает значение null."
                );
            }
            return default;
        }

        return (T?)OutputData;
    }

    private bool IsNullableType(Type type) =>
        type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);

}
