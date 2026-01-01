namespace Infrastructure.Testing.Common;

    /// <summary>
    ///  Выходные данные для заглушки.
    /// </summary>
    public class StubOutput
    {
        #region Свойства

        /// <summary>
        /// Получает или задает выходные данные для заглушки.
        /// </summary>
        public required object OutputData { get; set; }

        #endregion

        #region Методы

        /// <summary>
        /// Получает выходные данные, конвертированные в указанный тип.
        /// </summary>
        /// <typeparam name="T">Целевой тип данных для приведения.</typeparam>
        /// <returns>
        /// Экземпляр типа <typeparamref name="T"/>, если <see cref="OutputData"/> имеет точно такой же тип.
        /// </returns>
        /// <exception cref="InvalidCastException">Исключение, возникающее, когда фактический тип <see cref="OutputData"/>
        /// не совпадает с <typeparamref name="T"/>.</exception>
        public T GetOutputData<T>()
        {
            if ( OutputData.GetType() != typeof(T))
            {
                throw new InvalidCastException($"Не удалось привести тип {OutputData.GetType()} к {typeof(T)}." +
                                               $"Свойство {nameof(OutputData)} требует точного совпадения типов.");
            }

            return (T)OutputData;
        }

        #endregion
    }
