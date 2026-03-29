namespace Infrastructure.AspNetCore;

/// <summary>
/// Базовый компонент для настройки приложения ASP.NET Core.
/// </summary>
/// <remarks>
/// Предоставляет общую структуру для регистрации сервисов и настройки конвейера HTTP‑запросов.
/// </remarks>
public class StartupBase
{
    /// <summary>
    /// Получает настройки приложения из конфигурации.
    /// </summary>
    public IConfiguration Configuration { get; }

    /// <summary>
    /// Инициализирует экземпляр <see cref="StartupBase"/>.
    /// </summary>
    /// <param name="configuration">Объект конфигурации приложения.</param>
    /// <exception cref="ArgumentNullException">
    /// Выбрасывается, если <paramref name="configuration"/> равен <c>null</c>.
    /// </exception>
    public StartupBase(IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));
        Configuration = configuration;
    }

    /// <summary>
    /// Выполняет регистрацию сервисов, используемых в приложении, в DI-контейнер.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    /// <exception cref="ArgumentNullException">
    /// Выбрасывается, если <paramref name="configuration"/> равен <c>null</c>.
    /// </exception>
    public virtual void ConfigureServices(IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));
    }

    /// <summary>
    /// Настраивает конвейер обработки HTTP‑запросов приложения.
    /// </summary>
    /// <param name="app">Экземпляр веб‑приложения, используемый для настройки конвейера запросов.</param>
    /// <exception cref="ArgumentNullException">
    /// Выбрасывается, если <paramref name="configuration"/> равен <c>null</c>.
    /// </exception>
    public virtual void Configure(WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));
    }
}
