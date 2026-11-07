namespace Infrastructure.Wpf.Services.Regions
{
    /// <summary>
    /// Сервис области.
    /// </summary>
    /// <remarks>
    /// Сервис управляет содержимым области:
    /// <list type="bullet">
    ///   <item><description>Показывает элемент области;</description></item>
    ///   <item><description>Закрывает элемент области;</description></item>
    ///   <item><description>Закрывает все элементы области.</description></item>
    /// </list>
    /// </remarks>
    public interface IRegionService
    {
        /// <summary>
        /// Показывает элемент области.
        /// </summary>
        /// <typeparam name="TViewModel">Тип данных модели представления элемента области.</typeparam>
        /// <param name="viewModel">Модель представления элемента области.</param>
        void Show<TViewModel>(TViewModel viewModel) where TViewModel : class;

        /// <summary>
        /// Закрывает все элементы области.
        /// </summary>
        void CloseAll();
    }
}
