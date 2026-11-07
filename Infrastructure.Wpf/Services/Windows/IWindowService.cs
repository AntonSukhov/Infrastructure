namespace Infrastructure.Wpf.Services.Windows
{
    /// <summary>
    /// Сервис обычного окна.
    /// </summary>
    public interface IWindowService
    {
        /// <summary>
        /// Показывает окно.
        /// </summary>
        /// <typeparam name="TViewModel">Тип данных модели представления окна.</typeparam>
        /// <param name="viewModel">Модель представления окна.</param>
        void Show<TViewModel>(TViewModel viewModel) where TViewModel : class;
    }
}
