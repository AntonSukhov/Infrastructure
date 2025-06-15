using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Network.Services;

/// <summary>
/// Сервис для создания и настройки Http-клиента.
/// </summary>
public static class HttpClientService
{
    #region Поля

    private static readonly ServiceProvider _defaultServiceProvider = InitializeServiceProvider();

    #endregion

    #region Методы

    /// <summary>
    /// Создаёт экземпляр Http-клиента с настройками по умолчанию.
    /// </summary>
    /// <returns>Экземпляр Http-клиента с настройками по умолчанию, готовый к использованию.</returns>
    /// <exception cref="InvalidOperationException">Выбрасывается, если фабрика Http-клиентов
    /// не была зарегистрирована в контейнере зависимостей.</exception>
    public static HttpClient CreateDefaultHttpClient()
    {
        var httpClientFactory = _defaultServiceProvider.GetService<IHttpClientFactory>();

        if (httpClientFactory == null)
        {
            throw new InvalidOperationException($"{nameof(httpClientFactory)} не была зарегистрирована в {nameof(_defaultServiceProvider)}.");
        }

        var httpClient = httpClientFactory.CreateClient();

        return httpClient;
    }

    /// <summary>
    /// Инициализирует провайдер сервисов и регистрирует необходимые сервисы.
    /// </summary>
    /// <returns>Провайдер сервисов с зарегистрированными сервисами.</returns>
    private static ServiceProvider InitializeServiceProvider()
    {
        var services = new ServiceCollection();
        services.AddHttpClient();

        return services.BuildServiceProvider();
    }

    #endregion
}
