using Infrastructure.Wpf.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Infrastructure.Wpf.Services.Windows
{
    /// <summary>
    /// Реализация сервиса обычного окна.
    /// </summary>
    public class WindowService : IWindowService
    {
        private readonly Dictionary<Type, WindowConfiguration> _windowConfigurations;

        /// <summary>
        /// Инициализирует экземпляр <see cref="WindowService"/>.
        /// </summary>
        /// <param name="windowConfigurations">Конфигурации обычного окна.</param>
        /// <exception cref="ArgumentNullException"/>
        public WindowService(Dictionary<Type, WindowConfiguration> windowConfigurations)
        {
            _windowConfigurations = windowConfigurations
                ?? throw new ArgumentNullException(nameof(windowConfigurations));
        }

        /// <inheritdoc/>
        public void Show<TViewModel>(TViewModel viewModel) where TViewModel : class
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var type = viewModel.GetType();

            if (!_windowConfigurations.TryGetValue(type, out var config))
                throw new NotSupportedException($"Нет конфигурации для {type.FullName}");

            // Сначала ищем существующее окно — ДО создания нового
            if (!config.AllowMultipleInstances)
            {
                var existingWindow = Application.Current.Windows
                    .OfType<Window>()
                    .FirstOrDefault(w => w.DataContext is TViewModel);

                if (existingWindow != null)
                {
                    existingWindow.Activate();
                    return;
                }
            }

            // Создаём окно, только если дубликата нет
            var windowFactory = config.WindowFactory
                ?? throw new InvalidOperationException($"{nameof(config.WindowFactory)} не определен.");
            var window = windowFactory();
            window.DataContext = viewModel;

            // Проверка и определение владельца окна
            if (config.OwnerFactory != null)
            {
                var owner = config.OwnerFactory();
                window.Owner = owner
                    ?? throw new InvalidOperationException($"{nameof(config.OwnerFactory)} вернул null.");
            }

            if (config.IsModal)
            {
                window.ShowDialog();
            }
            else
            {
                window.Show();
            }
        }
    }
}
