namespace Infrastructure.Wpf.Enums
{
    /// <summary>
    /// Определяет варианты кнопок, которые могут отображаться в уведомлении.
    /// </summary>
    public enum NotificationButton
    {
        /// <summary>
        /// Только кнопка «ОК».
        /// </summary>
        OK,

        /// <summary>
        /// Кнопки «ОК» и «Отмена».
        /// </summary>
        OKCancel,

        /// <summary>
        /// Кнопки «Да» и «Нет».
        /// </summary>
        YesNo,

        /// <summary>
        /// Все три кнопки: «Да», «Нет» и «Отмена».
        /// </summary>
        YesNoCancel
    }

}
