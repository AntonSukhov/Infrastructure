using System;
using System.Windows;

namespace Infrastructure.Wpf.Configurations
{
    /// <summary>
    /// Конфигурационный объект для настройки диалога перед отображением.
    /// </summary>
    public class DialogConfiguration
    {
        /// <summary>
        /// Получает или задает фабрику создания окна диалога.
        /// </summary>
        /// <value>Фабрика создания окна диалога.</value>
        public Func<Window> WindowFactory { get; set; }

        /// <summary>
        /// Получает или задает фабрику создания владельца окна диалога.
        /// </summary>
        /// <remarks>
        /// Возможные сценарии для владельца:
        /// <list type="bullet">
        ///     <item><description>Динамический: <c>ActiveWindow</c> (текущее активное окно).</description></item>
        ///     <item><description>Статический: <c>MainWindow</c> (главное окно приложения).</description></item>
        ///     <item><description><c>null</c>: используется дефолтное поведение WPF (родитель не устанавливается).</description></item>
        /// </list>
        /// </remarks>
        /// <value>Фабрика создания владельца окна диалога.</value>
        public Func<Window> OwnerFactory { get; set; }
    }
}
