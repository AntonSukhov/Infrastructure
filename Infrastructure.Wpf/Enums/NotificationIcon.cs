namespace Infrastructure.Wpf.Enums
{
    /// <summary>
    /// Иконка, отображаемая в уведомлении.
    /// </summary>
    public enum NotificationIcon
    {
        /// <summary>
        /// Без иконки.
        /// </summary>
        None,

        /// <summary>
        /// Информационная иконка.
        /// </summary>
        /// <remarks>Обычно синий значок «i».</remarks>
        Information,

        /// <summary>
        /// Предупреждающая иконка.
        /// </summary>
        /// <remarks>Обычно жёлтый треугольник.</remarks>
        Warning,

        /// <summary>
        /// Иконка ошибки.
        /// </summary>
        /// <remarks>Обычно красный крестик.</remarks>
        Error,

        /// <summary>
        /// Иконка вопроса.
        /// </summary>
        /// <remarks>Обычно синий вопросительный знак.</remarks>
        Question
    }
}
