using Infrastructure.Wpf.Enums;

namespace Infrastructure.Wpf.Services.Notifications
{
    /// <summary>
    /// Сервис уведомления пользователя.
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Показывает уведомление пользователя.
        /// </summary>
        /// <param name="message">Текст уведомления.</param>
        /// <param name="caption">Заголовок окна уведомления.</param>
        /// <param name="button">Набор кнопок. По умолчанию <see cref="NotificationButton.OK"/>.</param>
        /// <param name="icon">Иконка уведомления. По умолчанию <see cref="NotificationIcon.Information"/>.</param>
        /// <returns>Результат уведомления пользователя.</returns>
        NotificationResult Show(string message,
                                string caption,
                                NotificationButton button = NotificationButton.OK,
                                NotificationIcon icon = NotificationIcon.Information);
    }
}
