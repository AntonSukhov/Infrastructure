namespace Infrastructure.Wpf.Enums
{
    /// <summary>
    /// Результат взаимодействия пользователя с уведомлением.
    /// </summary>
    public enum NotificationResult
    {
        /// <summary>
        /// Результат не определён или действие не было выполнено.
        /// </summary>
        None,

        /// <summary>
        /// Пользователь нажал «ОК».
        /// </summary>
        OK,

        /// <summary>
        /// Пользователь нажал «Отмена».
        /// </summary>
        Cancel,

        /// <summary>
        /// Пользователь выбрал «Да».
        /// </summary>
        Yes,

        /// <summary>
        /// Пользователь выбрал «Нет».
        /// </summary>
        No
    }
}
