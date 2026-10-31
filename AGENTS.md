# Инструкции для Koda: решение Infrastructure

Это файл проектных инструкций. Он описывает, что это за репозиторий, как его собирать и
тестировать, и какие соглашения соблюдать при изменениях.

## Что это за проект

`Infrastructure` — это набор NuGet-пакетов с переиспользуемой инфраструктурой для .NET-приложений
(кэш, безопасность, сериализация JSON, маппинг, EF Core, HTTP, MVVM, базовые примитивы для тестов).
Это **библиотека, а не приложение**: исполняемого входа нет, `bin/`/`obj/` — артефакты сборки.

- Автор пакетов: `Sukhov A.A.`, репозиторий: https://github.com/AntonSukhov/Infrastructure
- Решение: `Infrastructure.sln` (19 проектов), ветка по умолчанию: `main`
- Конфигурации стиля нет: в репозитории **нет** `.editorconfig`, `Directory.Build.props`,
  `Directory.Packages.props` и CI-конфигов. Стилистически ориентируемся на соседний код.

## Команды

```bash
dotnet build Infrastructure.sln                       # сборка всего решения
dotnet build Infrastructure.Caching/Infrastructure.Caching.csproj   # сборка одного проекта

# Тесты: обязателен DOTNET_ROLL_FORWARD, см. «Особенности окружения»
DOTNET_ROLL_FORWARD=Major dotnet test Infrastructure.sln --no-build
DOTNET_ROLL_FORWARD=Major dotnet test Infrastructure.Caching.Tests/Infrastructure.Caching.Tests.csproj --no-build

dotnet pack Infrastructure.Shared/Infrastructure.Shared.csproj -c Release -o ./nupkg   # сборка пакета
```

Перед сдачей изменения минимально достаточная проверка — `dotnet build` всего решения плюс
`dotnet test` затронутых тестовых проектов.

## Особенности окружения (проверено локально)

- SDK: в `global.json` указан `9.0.100` с `rollForward: latestMajor`; локально установлен SDK `10.0.114`,
  поэтому сборка идёт без правок `global.json`.
- Из рантаймов установлен только `Microsoft.NETCore.App 10.0.14`, а тестовые проекты таргетят `net9.0`.
  Без `DOTNET_ROLL_FORWARD=Major` `dotnet test` падает с «You must install or update .NET to run this
  application» — это проблема окружения, а не кода.
- Два теста падают на локальной машине **не из-за дефектов кода** (до изменений они уже красные):
  - `Infrastructure.Shared.Tests` → `GetSecretTests.ForExistedSecretSectionNameAndUsersecretsId`:
    требует пользовательских секретов. Поднять локально:
    `dotnet user-secrets set "SK:ServiceApiKey" "<значение>" -p Infrastructure.Shared.Tests`
    (используется `UserSecretsId` `705078df-8a7d-41c8-b13a-d9f26020eff8`).
  - `Infrastructure.Networks.Tests` → `PostAsyncTests.ForCorrectInputParams`: реальный HTTP-запрос к
    `https://jsonplaceholder.typicode.com/posts`, падает без сети/интернета (таймаут 10 с).
  - `Infrastructure.EntityFramework.Tests` и `Infrastructure.Testing.XUnit` сообщают «нет доступных
    тестов» — в первом пока нет исходников, второй является библиотекой.
- Ожидаемые предупреждения сборки: 3 nullable-предупреждения (`CS8600/CS8603/CS8604`) в
  `Infrastructure.EntityFramework/Extensions/QueryableExtensions.cs`. Новых предупреждений быть не должно.

## Карта проектов

Библиотеки (все `IsPackable`, метаданные NuGet описаны в `.csproj`, `Description` — на английском):

| Проект | TFМ | Версия | Зависимости | Назначение |
| --- | --- | --- | --- | --- |
| `Infrastructure.Shared` | net9.0 | 1.0.6 | Microsoft.Extensions.Configuration(+UserSecrets) | `JsonSerializationService`, `ConfigurationHelper`, `ConstantsHelper`, `PageOptionsModel` |
| `Infrastructure.Security` | net9.0 | 1.0.1 | — | `CryptographyService`: AES-шифрование, генерация HMAC-ключа |
| `Infrastructure.Caching` | net9.0 | 1.0.2 | Microsoft.Extensions.Caching.Memory | `ICacheService<TKey,TValue>`, `MemoryCacheService<TKey,TValue>` |
| `Infrastructure.Networks` | net9.0 | 2.0.0 | → Shared | `HttpClientExtension.PostAsync<TIn,TOut>`, enum `MediaType` + `MediaTypeExtension` |
| `Infrastructure.EntityFramework` | net9.0 | 1.0.4 | EF Core 9 + → Shared | `DbContextBase` (Add/Update/Remove с Detach), `QueryableExtensions` (`LeftJoin`, `Page`, `ToListAsync`) |
| `Infrastructure.Mapping` | net9.0 | 1.0.0 | — | `IMapper<TSource,TDest>`, `IDataMapper<TSource,TDest,TData>`, `CollectionMappingExtensions` |
| `Infrastructure.Mapping.AutoMapper` | net9.0 | 1.0.0 | AutoMapper 16 + → Mapping | `Mapper<TSource,TDest>` — адаптер над AutoMapper |
| `Infrastructure.AspNetCore` | net9.0 | 1.0.1 | SDK.Web, `OutputType=Library` | `StartupBase` (Configuration/Environment + виртуальные `ConfigureServices`/`Configure`) |
| `Infrastructure.Disposable` | net9.0 | 1.0.1 | — | `DisposableBase` — sync/async освобождение ресурсов + финализатор |
| `Infrastructure.Foundation` | netstandard2.0 | 1.0.0 | — | MVVM: `RelayCommand`, `RelayCommand<T>`, `NotifyPropertyChangedBase`, `NotifyPropertyChangedWithValuesBase` |
| `Infrastructure.Testing` | net9.0 | 1.0.5 | — | Модель тест-сценариев: `TestCase*`, `StubOutput`, `StubOutputKey` |
| `Infrastructure.Testing.XUnit` | net9.0 | 1.0.2 | xunit | `BaseTest<TFixture>`, `AssertHelper` |

Тестовые проекты: `Infrastructure.Caching.Tests`, `Infrastructure.EntityFramework.Tests`,
`Infrastructure.Mapping.Tests`, `Infrastructure.Networks.Tests`, `Infrastructure.Security.Tests`,
`Infrastructure.Shared.Tests`, `Infrastructure.Testing.Tests`.

Граф зависимостей: `Shared` ← (`EntityFramework`, `Networks`); `Mapping` ← `Mapping.AutoMapper`;
`Testing` + `Testing.XUnit` ← (`Mapping.Tests`, `Testing.Tests`). Из-за этого правка `Shared`
или `Mapping` требует сборки/проверки и зависимых пакетов.

## Соглашения по коду

- **Пространства имён** совпадают с путём к файлу (`Infrastructure.Caching.Services`). В проектах
  `net9.0` — file-scoped namespace (`namespace X;`) и `ImplicitUsings`/`Nullable` включены. В
  `Infrastructure.Foundation` и части тестов (`Networks.Tests`, `Testing.XUnit`) — блочные
  неймспейсы и явные `using`; не «унифицируем» это без необходимости.
- **XML-документация на русском языке** обязательна для публичных членов (`/// <summary>`,
  `<param>`, `<returns>`, `<exception>`); на реализациях интерфейсов достаточно `/// <inheritdoc/>`.
  Часть файлов имеет UTF-8 BOM — не убираем его.
- **Проверка аргументов** в начале публичных методов: `ArgumentNullException.ThrowIfNull(x, nameof(x))`,
  `ArgumentException.ThrowIfNullOrWhiteSpace(x)`. Для `netstandard2.0` — `x ?? throw new ArgumentNullException(nameof(x))`.
- **Члены группировать** `#region Поля / Конструкторы / Методы` там, где в файле это уже принято.
- Асинхронные методы — суффикс `Async` и возврат `Task`/`ValueTask`; `ConfigureAwait(false)` только
  в библиотеках, вызываемых из UI-кода (см. `DisposableBase`).
- Новые методы/классы добавляем в существующую структуру папок проекта (`Services/`, `Helpers/`,
  `Extensions/`, `Models/`, `Interfaces/`, `Enums/`, `DbContexts/`, `Bindings/`, `Commands/`).
- Любая правка публичного API пакета требует обновления версии `Version` в `.csproj` (semver) —
  но только если об этом есть явная просьба пользователя; иначе версию не трогаем.

## Соглашения по тестам

Два принятых стиля; при правках выбираем тот, что уже используется в конкретном тестовом проекте.

1. **`TestData` + xunit `Theory`** (`Caching.Tests`, `Security.Tests`, `Shared.Tests`, `Networks.Tests`):
   - на каждый метод тестируемого класса — свой файл `<Метод>Tests.cs` в папке `<Класс>Tests/`;
   - данные — класс `For<Сценарий>TestData` в `TestData/<Класс>/<Метод>/`: либо наследник
     `TheoryData<...>` (подключение через `[ClassData(typeof(...))]`), либо статический
     `GetTestData()` (через `[MemberData(nameof(...), MemberType = typeof(...))]` — так в `Networks.Tests`);
   - имена тестов: `ForCorrectInputParams`, `ForIncorrectInputParams`, `ForExistedKey`,
     `ForNotExistedKey`, `ForExistDepartment` и т.п.; шаги помечаются комментариями
     `// Arrange:`, `// Act:`, `// Assert:`;
   - Assertions: в `Caching.Tests`/`Security.Tests` — FluentAssertions, в остальных — `Assert` xUnit.
 2. **Модель тест-сценариев из `Infrastructure.Testing`** (`Mapping.Tests`, `Testing.Tests`):
    `BaseTest<TFixture>` + фикстура + `TestCase...`/`TestCaseWithStubs...` через `MemberData`.
    Описание модели — в `Infrastructure.Testing/README.md`.

## Шаблон README библиотеки

Документация публичного API — в `README.md` самого проекта (не в корневом), **на английском языке**
(метрики NuGet/`Description` тоже на английском). Порядок секций — как в
`Infrastructure.Foundation/README.md`, который принят за эталон:

1. Заголовок `# <PackageId>` + 1–3 строки summary (для кого пакет и какую проблему закрывает).
2. `## About` — что даёт пакет (пункты `a) b) c)`).
3. `## Features` — таблица «механизм → тип → зачем».
4. `## Class Diagram` — Mermaid `classDiagram` (см. правила ниже).
5. `## Installation` — `dotnet add package` + вариант `PackageReference` с текущей `Version`.
6. `## How to Use` — пронумерованные сценарии, каждый пример самодостаточен (реальные имена типов
   и членов из исходников, компилируется как есть).
7. `## Main Types` — полный список публичных типов с `Infrastructure.<Package>.<Namespace>` и одним
   предложем описания; ни одного типа из кода не пропускаем.
8. `## Target Framework & Compatibility` — TFМ, `Nullable`/`ImplicitUsings`, внешние зависимости.
9. `## Notes and known behaviors` — зафиксированное текущее поведение (исключения, no-op, порядок
   событий, отсутствие маршалинга на UI-поток и т.п.). Это важно: читатель не выведет такое из сигнатур.
10. `## Package Details` — таблица метаданных из `.csproj` (id, версия, TFМ, лицензия, автор,
    репозиторий, теги).
11. `## Related Packages` — 2–4 соседних пакета решения, которые обычно используют вместе.
12. `## Feedback & Contributing` + `## License`.

### Правила для диаграммы классов (Mermaid)

- Блок ` ```mermaid ` с `classDiagram` и `direction LR`; диаграмма **компактная**: только публичный
  API и связи наследования/реализации, без приватных полей и конструкторов, ≤ 8 узлов.
- Интерфейсы — `<<interface>>`; реализация контракта — `..|>`, наследование класса — `<|--`,
  создание/использование типа — `..>` с подписью (`: raises`, `: creates`, ...).
- Дженерики — в тильдах (`class RelayCommand~T~`), отображается как `RelayCommand<T>`. Ограничения
  Mermaid, которые нужно обходить заранее:
  - дженерик **с запятой** внутри (`~TIn, TOut~`) не поддерживается — такие типы в диаграмме подписываем
    без параметров или через `class Id["Label"]`;
  - два класса с одинаковым именем и разными дженериками невозможны (имя узла берётся без части `~T~`),
    поэтому для нетипизированной версии заводим отдельный id и даём настоящее имя подписью:
    `class RelayCommandNonGeneric["RelayCommand"]`;
  - в строках связей имя класса указываем **без** части `~T~` (`RelayCommand ..|> ICommand`);
  - имена узлов — только буквы/цифры/`_`/`-`.
- Параметры методов в членах: один параметр (`+CanExecute(object parameter) bool`) — безопасно;
  списки с запятой не используем, полную сигнатуру приводим текстом под диаграммой.
- Возвращаемый тип отделяем от `()` пробелом.
- Если README публикуется в NuGet, требуется `<PackageReadmeFile>` в `.csproj`; не добавляем его
  без явной просьбы.
- После правки диаграммы — проверка, что она не ломает сборку, и (при наличии node/mermaid-cli)
  валидация синтаксиса; в этом окружении node отсутствует, поэтому синтаксис сверяем с документацией
  Mermaid вручную.


## Правила для агента

- Запрос «изучи/объясни» не даёт права менять файлы. Запрос «не рефактори» означает: правки только
  точечные, без переименований, изменения порядка членов, переформатирования и «улучшения» соседнего кода.
- Не менять `.csproj` зависимых проектов «на всякий случай», не апгрейдить версии пакетов
  (они в каждом `.csproj` свои, централизованного управления версиями нет).
- Не коммитить и не пушить без явной просьбы. Сообщения коммитов — на русском (см. `git log`).
- Секреты не выносить в репозиторий: значения берутся через user-secrets (`ConfigurationHelper.GetSecret`).
- Артефакты `bin/`, `obj/` не редактировать и не добавлять в индекс.
