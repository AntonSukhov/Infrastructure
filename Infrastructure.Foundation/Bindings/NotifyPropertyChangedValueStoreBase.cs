using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Infrastructure.Foundation.Bindings
{
    /// <summary>
    /// Базовая реализация уведомления клиентов об изменении значения их свойств без скрытых полей.
    /// </summary>
    public class NotifyPropertyChangedValueStoreBase : NotifyPropertyChangedBase
    {
        /// <summary>
        /// Хранилище значений свойств: ключ - имя свойства, значение - последняя установленная величина.
        /// </summary>
        private readonly Dictionary<string, object> _values = new Dictionary<string, object>();

        /// <summary>
        /// Получение значения свойства из хранилища.
        /// </summary>
        /// <typeparam name="T">Тип данных свойства.</typeparam>
        /// <param name="propertyName">Название свойства.</param>
        /// <returns>
        /// Значение свойства, либо <c>default</c> для типа <typeparamref name="T"/>,
        /// если значение свойства ещё ни разу не устанавливалось.
        /// </returns>
        /// <exception cref="ArgumentNullException">Не указано название свойства.</exception>
        /// <exception cref="InvalidCastException">
        /// Сохранённое значение нельзя привести к типу <typeparamref name="T"/>.
        /// </exception>
        protected virtual T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));

            if (!_values.TryGetValue(propertyName, out var stored))
                return default;

            if (stored == null)
                return default;

            if (stored is T value)
                return value;

            throw new InvalidCastException(
                $"Значение свойства \"{propertyName}\" имеет тип \"{stored.GetType()}\", запрошен тип \"{typeof(T)}\".");
        }

        /// <summary>
        /// Установка значения свойства в хранилище и уведомление об изменении.
        /// </summary>
        /// <typeparam name="T">Тип данных свойства.</typeparam>
        /// <param name="value">Устанавливаемое значение свойства.</param>
        /// <param name="propertyName">Название свойства.</param>
        /// <returns>Признак установки значения свойства.</returns>
        /// <exception cref="ArgumentNullException">Не указано название свойства.</exception>
        protected virtual bool SetValue<T>(T value, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));

            var current = _values.TryGetValue(propertyName, out var stored) && stored is T typed
                ? typed
                : default;

            // Значение по умолчанию ещё не хранится, поэтому его повторная установка изменением не считается.
            if (EqualityComparer<T>.Default.Equals(current, value))
                return false;

            _values[propertyName] = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// Установка значения поля по ссылке и уведомление об изменении.
        /// Перегрузка сохранена, чтобы в одном классе можно было смешивать свойства
        /// со скрытым полем и свойства на основе хранилища.
        /// </summary>
        /// <typeparam name="T">Тип данных поля.</typeparam>
        /// <param name="field">Поле.</param>
        /// <param name="value">Устанавливаемое значение поля.</param>
        /// <param name="propertyName">Название свойства.</param>
        /// <returns>Признак установки значения свойства.</returns>
        protected new bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
            => base.SetValue(ref field, value, propertyName);
    }
}
