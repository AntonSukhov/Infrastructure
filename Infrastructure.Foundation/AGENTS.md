# Инструкции: Infrastructure.Foundation

MVVM-примитивы для WPF: `Commands/RelayCommand`, `Commands/RelayCommand<T>`,
`Bindings/NotifyPropertyChangedBase`, `Bindings/NotifyPropertyChangedWithValuesBase`,
`Bindings/PropertyChangedWithValuesEventArgs<T>`.

## Ограничения проекта (важно)

- TFМ — `netstandard2.0`, `Nullable=disable`, `ImplicitUsings=disable`. Отсюда:
  - нужны **явные `using`** (`System`, `System.ComponentModel`, `System.Runtime.CompilerServices`, …);
  - недоступны `ArgumentNullException.ThrowIfNull`, `ArgumentException.ThrowIfNullOrWhiteSpace`,
    `required`, record-структуры и другие черты C# 9+ — в конструкторах используем
    `x ?? throw new ArgumentNullException(nameof(x))`;
  - события объявляем без `?` (`public event EventHandler CanExecuteChanged;`): аннотации
    nullable в проекте выключены, как в существующих файлах.
- **Блочные пространства имён** (`namespace X { }`), а не file-scoped — в этом проекте принято так.
- `System.Windows.Input.ICommand` берётся из контрактов netstandard2.0; проект не ссылается на WPF,
  поэтому здесь не появляется ничего, что требует `PresentationCore`/`Dispatcher`.

## Соглашения

- XML-документация на русском; на реализациях `ICommand` — `/// <inheritdoc/>`.
- Публичные команды уведомляют о смене состояния через `RaiseCanExecuteChanged()`.
- `RelayCommand<T>` — типобезопасная версия: при несовпадении типа параметра `Execute` молча ничего
  не делает, а `CanExecute` возвращает `false` (не бросаем исключение — поведение уже зафиксировано
  тестопотребителями в UI-приложениях).
- `NotifyPropertyChangedWithValuesBase` наследует `NotifyPropertyChangedBase` и переопределяет
  `SetValue<T>`: сначала стандартное `OnPropertyChanged`, затем `PropertyChangedWithValues`
  с предыдущим и текущим значениями. Порядок событий не меняем.

## Правила для агента

- Новый код добавляем в `Commands/` или `Bindings/`; другие папки не заводим без необходимости.
- `README.md` этого проекта — **эталонный шаблон** документации для остальных библиотек решения
  (структура секций и требования к диаграмме классов зафиксированы в корневом `AGENTS.md`). При
  добавлении/удалении публичного типа синхронно обновляем секции `Class Diagram` и `Main Types`.
- Не переводим проект на `net9.0`/`netstandard2.1` и не «улучшаем» стиль до file-scoped namespace —
  это сломает потребителей пакета.
- Тестового проекта у `Infrastructure.Foundation` нет; проверка изменений — `dotnet build`
  решения (команды в корневом `AGENTS.md`).
