using Infrastructure.Wpf.Enums;
using System.Windows;

namespace Infrastructure.Wpf.Services.Notifications
{
    /// <summary>
    /// Сервис уведомления пользователя через системный <see cref="MessageBox"/>.
    /// </summary>
    public class MessageBoxNotificationService : INotificationService
    {
        /// <inheritdoc/>
        public NotificationResult Show(string message,
                                       string caption,
                                       NotificationButton button = NotificationButton.OK,
                                       NotificationIcon icon = NotificationIcon.Information)
        {
            var owner = Application.Current?.MainWindow;

            var messageBoxButton = ToMessageBoxButton(button);
            var messageBoxImage = ToMessageBoxImage(icon);
            var messageBoxResult = MessageBox.Show(owner, message, caption, messageBoxButton, messageBoxImage);
            var notificationResult = ToNotificationResult(messageBoxResult);

            return notificationResult;
        }

        private MessageBoxButton ToMessageBoxButton(NotificationButton button)
        {
            switch (button)
            {
                case NotificationButton.OK:
                    return MessageBoxButton.OK;
                case NotificationButton.OKCancel:
                    return MessageBoxButton.OKCancel;
                case NotificationButton.YesNo:
                    return MessageBoxButton.YesNo;
                case NotificationButton.YesNoCancel:
                    return MessageBoxButton.YesNoCancel;
                default:
                    return MessageBoxButton.OK;
            }
        }

        private MessageBoxImage ToMessageBoxImage(NotificationIcon icon)
        {
            switch (icon)
            {
                case NotificationIcon.None:
                    return MessageBoxImage.None;
                case NotificationIcon.Information:
                    return MessageBoxImage.Information;
                case NotificationIcon.Warning:
                    return MessageBoxImage.Warning;
                case NotificationIcon.Error:
                    return MessageBoxImage.Error;
                case NotificationIcon.Question:
                    return MessageBoxImage.Question;
                default:
                    return MessageBoxImage.None;
            }
        }

        private NotificationResult ToNotificationResult(MessageBoxResult result)
        {
            switch (result)
            {
                case MessageBoxResult.None:
                    return NotificationResult.None;
                case MessageBoxResult.OK:
                    return NotificationResult.OK;
                case MessageBoxResult.Cancel:
                    return NotificationResult.Cancel;
                case MessageBoxResult.Yes:
                    return NotificationResult.Yes;
                case MessageBoxResult.No:
                    return NotificationResult.No;
                default:
                    return NotificationResult.None;
            }
        }
    }
}
