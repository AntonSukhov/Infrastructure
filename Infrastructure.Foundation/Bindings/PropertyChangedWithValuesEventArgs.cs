using System;

namespace Infrastructure.Foundation.Bindings
{
    /// <summary>
    /// Аргументы события изменения свойства с предыдущим и текущим значениями.
    /// </summary>
    /// <typeparam name="T">Тип данных свойства.</typeparam>
    public class PropertyChangedWithValuesEventArgs<T>: EventArgs
    {
        /// <summary>
        /// Получает название свойства, значение которого изменилось.
        /// </summary>
        /// <value>Название свойства, значение которого изменилось.</value>
        public string PropertyName { get; }
        
        /// <summary>
        /// Получает предыдущее значение свойства.
        /// </summary>
        /// <value>Предыдущее значение свойства.</value>
        public T PreviousValue { get; }
        
        /// <summary>
        /// Получает предыдущее значение свойства.
        /// </summary>
        /// <value>Предыдущее значение свойства.</value>
        public T CurrentValue { get; }

        /// <summary>
        /// Инициализирует экземпляр <see cref="PropertyChangedWithValuesEventArgs{T}"/>.
        /// </summary>
        /// <param name="propertyName">Название свойства, значение которого изменилось.</param>
        /// <param name="previousValue">Предыдущее значение свойства.</param>
        /// <param name="currentValue">Текущее значение свойства.</param>
        public PropertyChangedWithValuesEventArgs(
            string propertyName,
            T previousValue,
            T currentValue)
        {
            PropertyName = propertyName;
            PreviousValue = previousValue;
            CurrentValue = currentValue;
        }
    }
}


