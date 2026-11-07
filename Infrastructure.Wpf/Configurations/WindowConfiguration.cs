using System;
using System.Windows;

namespace Infrastructure.Wpf.Configurations
{
    /// <summary>
    /// Конфигурационный объект для настройки обычного окна перед отображением.
    /// </summary>
    public class WindowConfiguration
    {
        /// <summary>
        /// Получает или задает фабрику создания окна.
        /// </summary>
        /// <value>Фабрика создания окна.</value>
        public Func<Window> WindowFactory { get; set; }

        /// <summary>
        /// Получает или задает фабрику создания владельца окна.
        /// </summary>
        /// <remarks>
        /// Владелец может быть: 
        /// <list type="bullet">
        ///     <item><description>Динамический: <c>ActiveWindow</c> (текущее активное окно).</description></item>
        ///     <item><description>Статический: <c>MainWindow</c> (главное окно приложения).</description></item>
        ///     <item><description><c>null</c>: используется дефолтное поведение WPF (родитель не устанавливается).</description></item>
        /// </list>
        /// </remarks>
        /// <value>Фабрика создания владельца окна.</value>
        public Func<Window> OwnerFactory { get; set; }

        /// <summary>
        /// Получает или задает признак модальности окна.
        /// </summary>
        /// <value>Признак модальности окна.</value>
        public bool IsModal { get; set; }

        /// <summary>
        /// Получает или задает признак открытия окна.
        /// </summary>
        /// <value>
        /// Признак открытия окна. 
        ///<list type="bullet">
        ///     <item><description><c>true</c> может открываться многократно.</description></item>
        ///     <item><description><c>false</c> может открываться в единственном экземпляре.</description></item>
        /// </list>
        /// </value>
        public bool AllowMultipleInstances { get; set; }
    }
}
