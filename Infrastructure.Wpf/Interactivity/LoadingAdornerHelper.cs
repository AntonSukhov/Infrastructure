using System.Windows;
using System.Windows.Documents;

namespace Infrastructure.Wpf.Interactivity
{
    /// <summary>
    /// Помощник для управления <see cref="LoadingAdorner"/>.
    /// </summary>
    public static class LoadingAdornerHelper
    {
        /// <summary>
        /// Зарегистрированное attached-свойство факта загрузки.
        /// </summary>
        /// <remarks>
        /// Значение <see cref="true"/> — загрузка идёт, покажи индикатор поверх элемента, 
        /// значение <see cref="false"/> — загрузка закончилась, убери индикатор.
        /// </remarks>
        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.RegisterAttached(
                "IsLoading",
                typeof(bool),
                typeof(LoadingAdornerHelper),
                new PropertyMetadata(false, OnIsLoadingChanged));

        /// <summary>
        /// Получает значение свойства <see cref="IsLoadingProperty"/>.
        /// </summary>
        /// <param name="obj">Объект зависимости, содержащий свойство <see cref="IsLoadingProperty"/>.</param>
        /// <returns>Значение свойства <see cref="IsLoadingProperty"/>.</returns>
        public static bool GetIsLoading(DependencyObject obj) =>
            (bool)obj.GetValue(IsLoadingProperty);

        /// <summary>
        /// Задает значение свойства <see cref="IsLoadingProperty"/>.
        /// </summary>
        /// <param name="obj">Объект зависимости, содержащий свойство <see cref="IsLoadingProperty"/>.</param>
        /// <param name="value">Новое значение свойства <see cref="IsLoadingProperty"/>.</param>
        public static void SetIsLoading(DependencyObject obj, bool value) =>
            obj.SetValue(IsLoadingProperty, value);

        /// <summary>
        /// Обработчик изменения значения свойства <see cref="IsLoadingProperty"/>.
        /// </summary>
        /// <remarks>
        /// Именно здесь происходит логика добавления или удаления <see cref="LoadingAdorner"/> на слое <see cref="AdornerLayer"/>.
        /// Метод вызывается автоматически при изменении значения свойства.
        /// </remarks>
        /// <param name="obj">Объект зависимости.</param>
        /// <param name="args">Аргументы события изменения значения свойства <see cref="IsLoadingProperty"/>.</param>
        private static void OnIsLoadingChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (obj is UIElement element)
            {
                var adornerLayer = AdornerLayer.GetAdornerLayer(element);
                if (adornerLayer == null)
                    return;

                var isLoading = (bool)args.NewValue;

                if (isLoading)
                {
                    if (GetExistingAdorner(adornerLayer, element) != null)
                        return;

                    var adorner = new LoadingAdorner(element);
                    adornerLayer.Add(adorner);
                }
                else
                {
                    var adorner = GetExistingAdorner(adornerLayer, element);

                    if (adorner != null)
                        adornerLayer.Remove(adorner);
                }
            }
        }

        /// <summary>
        /// Ищет среди адорнеров, привязанных к элементу, экземпляр типа LoadingAdorner.
        /// Нужен, чтобы не создавать дубликаты при повторной установке IsLoading=true
        /// и чтобы корректно удалять именно наш адорнер при IsLoading=false.
        /// </summary>
        private static Adorner GetExistingAdorner(AdornerLayer adornerLayer, UIElement element)
        {
            var adorners = adornerLayer.GetAdorners(element);

            if (adorners == null)
                return null;

            foreach (var adorner in adorners)
            {
                if (adorner is LoadingAdorner)
                    return adorner;
            }

            return null;
        }
    }
}
