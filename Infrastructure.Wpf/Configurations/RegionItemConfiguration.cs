using System;
using System.Windows.Controls;

namespace Infrastructure.Wpf.Configurations
{
    /// <summary>
    /// Конфигурационный объект для настройки элемента области (вкладки/региона) перед отображением.
    /// </summary>
    public class RegionItemConfiguration
    {
        /// <summary>
        /// Получает или задает фабрику создания <see cref="UserControl"/> элемента области.
        /// </summary>
        /// <value>Фабрика создания <see cref="UserControl"/> элемента области.</value>
        public Func<UserControl> ViewFactory { get; set; }

        /// <summary>
        /// Получает или задает заголовок элемента области.
        /// </summary>
        /// <value>Заголовок элемента области.</value>
        public string Title { get; set; } = string.Empty;
    }
}
