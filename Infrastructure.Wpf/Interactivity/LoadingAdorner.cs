using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Infrastructure.Wpf.Interactivity
{
    /// <summary>
    /// Панель загрузки.
    /// </summary>
    /// <remarks>
    /// Полупрозрачный слой с текстом и прогресс-баром поверх контрола.
    /// </remarks>
    public class LoadingAdorner : Adorner
    {
        private readonly VisualCollection _visualElements;
        private readonly Grid _overlay;

        /// <summary>
        /// Инициализация экземпляра <see cref="LoadingAdorner"/>.
        /// </summary>
        /// <param name="adornedElement">Загружаемый элемент, поверх которого будет накладываться слой загрузки.</param>
        /// <param name="text">Текст сообщения о загрузке.</param>
        public LoadingAdorner(UIElement adornedElement, string text = "Загрузка данных...")
            : base(adornedElement)
        {
            _visualElements = new VisualCollection(this);

            _overlay = new Grid
            {
                Background = new SolidColorBrush(Color.FromArgb(0xCC, 0xFF, 0xFF, 0xFF))
            };

            //Stack содержит текст и прогресс-бар по центру.
            var stack = new StackPanel
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            stack.Children.Add(new TextBlock
            {
                Text = text,
                FontSize = 14,
                Foreground = new SolidColorBrush(Color.FromRgb(0x70, 0x80, 0x90)),
                Margin = new Thickness(0, 0, 0, 8),
                HorizontalAlignment = HorizontalAlignment.Center
            });

            stack.Children.Add(new ProgressBar
            {
                IsIndeterminate = true,
                Width = 200,
                Height = 4
            });

            _overlay.Children.Add(stack);
            _visualElements.Add(_overlay);
        }

        /// <summary>
        /// Получает количество дочерних элементов.
        /// </summary>
        protected override int VisualChildrenCount => _visualElements.Count;

        /// <summary>
        /// Получает дочерний элемент.
        /// </summary>
        /// <param name="index">Индекс дочернего элемента.</param>
        /// <returns>Дочерний элемент.</returns>
        protected override Visual GetVisualChild(int index) => _visualElements[index];

        /// <summary>
        /// Задает размещение <see cref="_overlay"/> в <see cref="LoadingAdorner"/>.
        /// </summary>
        /// <param name="finalSize">Размер для размещения <see cref="_overlay"/>.</param>
        /// <returns>Итоговые размеры.</returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            _overlay.Arrange(new Rect(finalSize));
            return finalSize;
        }
    }
}
