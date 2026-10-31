using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Infrastructure.Foundation.Bindings
{
    /// <summary>
    /// Базовая реализация уведомления клиентов об изменении значения их свойств с предыдущим и текущим значениями.
    /// </summary>
    public class NotifyPropertyChangedWithValuesBase: NotifyPropertyChangedBase
    {
        /// <summary>
        /// Событие <see cref="PropertyChangedWithValues"/> для уведомления об изменении свойства 
        /// с предыдущим и текущим значениями.
        /// </summary>
        public event EventHandler<PropertyChangedWithValuesEventArgs<object>> PropertyChangedWithValues;

        /// <inheritdoc/>
        protected override bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            var previous = field;
            field = value;

            // Сначала стандартное событие для привязки.
            OnPropertyChanged(propertyName);

            // Затем расширенное событие с предыдущим и текущим значениями свойства.
            OnPropertyChangedWithValues(propertyName, previous, field);

            return true;
        }

        private void OnPropertyChangedWithValues<T>(string propertyName, T previous, T current)
        {
            var args = new PropertyChangedWithValuesEventArgs<object>(
                propertyName,
                previous,
                current);

            PropertyChangedWithValues?.Invoke(this, args);
        }
    }
}