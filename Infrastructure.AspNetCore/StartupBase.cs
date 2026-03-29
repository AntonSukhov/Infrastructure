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
    /// Получает информацию об окружении приложения.
    /// </summary>
    public IWebHostEnvironment Environment { get; }

    /// <summary>
    /// Инициализирует экземпляр <see cref="StartupBase"/>.
    /// </summary>
    /// <param name="configuration">Объект конфигурации приложения.</param>
    /// <param name="environment">Объект окружения приложения.</param>
    /// <exception cref="ArgumentNullException"/>
    public StartupBase(IConfiguration configuration, IWebHostEnvironment environment)
    {
        ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));
        ArgumentNullException.ThrowIfNull(environment, nameof(environment));

        Configuration = configuration;
        Environment = environment;
    }

    /// <summary>
    /// Выполняет регистрацию сервисов, используемых в приложении, в DI-контейнер.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    /// <exception cref="ArgumentNullException"/>
    public virtual void ConfigureServices(IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));
    }

    /// <summary>
    /// Настраивает конвейер обработки HTTP‑запросов приложения.
    /// </summary>
    /// <param name="app">Экземпляр веб‑приложения, используемый для настройки конвейера запросов.</param>
    /// <exception cref="ArgumentNullException"/>
    public virtual void Configure(WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));
    }
}
