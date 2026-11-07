using Infrastructure.Wpf.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Infrastructure.Wpf.Services.Regions
{
    /// <summary>
    /// Реализация сервиса области.
    /// </summary>
    public class RegionService : IRegionService
    {
        private readonly TabControl _tabControl;
        private readonly Dictionary<Type, RegionItemConfiguration> _regionConfigurations;

        /// <summary>
        /// Инициализирует экземпляр <see cref="RegionService"/>.
        /// </summary>
        /// <param name="tabControl">Контрол вкладок.</param>
        /// <param name="regionConfigurations">Конфигурации области.</param>
        /// <exception cref="ArgumentNullException"/>
        public RegionService(TabControl tabControl,
                             Dictionary<Type, RegionItemConfiguration> regionConfigurations)
        {
            _tabControl = tabControl
                ?? throw new ArgumentNullException(nameof(tabControl));
            _regionConfigurations = regionConfigurations
                ?? throw new ArgumentNullException(nameof(regionConfigurations));
        }

        /// <inheritdoc/>
        public void Show<TViewModel>(TViewModel viewModel) where TViewModel : class
        {
            if (!_regionConfigurations.TryGetValue(typeof(TViewModel), out var config))
            {
                throw new InvalidOperationException(
                    $"Для типа {typeof(TViewModel).Name} не зарегистрирована конфигурация элемента области.");
            }

            // Сначала ищем, не открыта ли уже эта вкладка
            foreach (TabItem tab in _tabControl.Items)
            {
                if (tab.Content is UserControl view &&
                    view.DataContext?.GetType() == typeof(TViewModel))
                {
                    _tabControl.SelectedItem = tab;

                    return;
                }
            }

            // Создаём новый элемент (вкладка)
            var newView = config.ViewFactory();
            newView.DataContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));

            var tabItem = CreateTabItem(config, newView);

            _tabControl.Items.Add(tabItem);
            _tabControl.SelectedItem = tabItem;
        }

        /// <inheritdoc/>
        public void CloseAll()
        {
            foreach (var tabItem in _tabControl.Items.OfType<TabItem>().ToList())
            {
                RemoveTab(tabItem);
            }
        }

        private TabItem CreateTabItem(RegionItemConfiguration config, UserControl view)
        {
            var header = new StackPanel { Orientation = Orientation.Horizontal };

            header.Children.Add(new TextBlock
            {
                Text = config.Title,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 6, 0)
            });

            var closeButton = new Button
            {
                Content = "✕",
                Width = 18,
                Height = 18,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                VerticalAlignment = VerticalAlignment.Center,
                ToolTip = "Закрыть вкладку"
            };

            var tabItem = new TabItem { Content = view };

            // Кнопка закрывает именно эту вкладку
            closeButton.Click += (s, e) => RemoveTab(tabItem);

            header.Children.Add(closeButton);
            tabItem.Header = header;

            return tabItem;
        }

        private void RemoveTab(TabItem tabItem)
        {
            tabItem.Template = null;
            _tabControl.Items.Remove(tabItem);
        }
    }
}
