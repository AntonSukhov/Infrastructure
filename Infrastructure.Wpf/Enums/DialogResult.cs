namespace Infrastructure.Wpf.Enums
{
    /// <summary>
    /// Результат диалога с пользователем.
    /// </summary>
    public enum DialogResult
    {
        /// <summary>
        /// Результат не определён.
        /// </summary>
        None = 0,

        /// <summary>
        /// Пользователь подтвердил действие.
        /// </summary>
        Confirmed = 1,

        /// <summary>
        /// Пользователь отменил действие.
        /// </summary>
        Cancelled = 2
    }
}
