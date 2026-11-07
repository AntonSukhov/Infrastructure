using Infrastructure.Wpf.Configurations;
using Infrastructure.Wpf.Enums;
using System;
using System.Collections.Generic;

namespace Infrastructure.Wpf.Services.Dialogs
{
    /// <summary>
    /// Реализация сервиса диалога с пользователем.
    /// </summary>
    public class DialogService : IDialogService
    {
        private readonly Dictionary<Type, DialogConfiguration> _dialogConfigurations;

        /// <summary>
        /// Инициализирует экземпляр <see cref="DialogService"/>.
        /// </summary>
        /// <param name="dialogConfigurations">Конфигурации диалога с пользователем.</param>
        /// <exception cref="ArgumentNullException"/>
        public DialogService(Dictionary<Type, DialogConfiguration> dialogConfigurations)
        {
            _dialogConfigurations = dialogConfigurations
                ?? throw new ArgumentNullException(nameof(dialogConfigurations));
        }

        /// <inheritdoc/>
        public DialogResult Show<TViewModel>(TViewModel viewModel) where TViewModel : class
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var type = viewModel.GetType();

            if (!_dialogConfigurations.TryGetValue(type, out var config))
                throw new NotSupportedException($"Нет конфигурации для {type.FullName}");

            var windowFactory = config.WindowFactory
                ?? throw new InvalidOperationException($"{nameof(config.WindowFactory)} не определен.");
            var window = windowFactory();
            window.DataContext = viewModel;

            if (config.OwnerFactory != null)
            {
                var owner = config.OwnerFactory();
                window.Owner = owner
                    ?? throw new InvalidOperationException($"{nameof(config.OwnerFactory)} вернул null.");
            }

            var dialogResult = window.ShowDialog();

            return dialogResult == true ? DialogResult.Confirmed : DialogResult.Cancelled;
        }
    }
}
