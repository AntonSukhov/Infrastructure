using Infrastructure.Wpf.Enums;

namespace Infrastructure.Wpf.Services.Dialogs
{
    /// <summary>
    /// Сервис диалога с пользователем.
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// Показывает диалог с пользователем.
        /// </summary>
        /// <typeparam name="TViewModel">Тип данных модели представления диалога.</typeparam>
        /// <param name="viewModel">Модель представления диалога.</param>
        /// <returns>Результат диалога.</returns>
        DialogResult Show<TViewModel>(TViewModel viewModel) where TViewModel : class;
    }
}