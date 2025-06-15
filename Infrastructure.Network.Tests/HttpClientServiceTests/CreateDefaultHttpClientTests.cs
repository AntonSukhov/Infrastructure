using FluentAssertions;
using Infrastructure.Network.Services;

namespace Infrastructure.Network.Tests.HttpClientServiceTests;

/// <summary>
/// Тесты для проверки метода генерации создания Http-клиента с настройками по умолчанию.
/// </summary>
public class CreateDefaultHttpClientTests
{
    #region Методы

    /// <summary>
    /// Тест проверки метода создания Http-клиента с настройками по умолчанию без выброса исключений.
    /// </summary>
    [Fact]
    public void NotThrowException()
    {
        var func = () => HttpClientService.CreateDefaultHttpClient();

        func.Invoking(f => f()).Should().NotThrow()
                               .Which.Should().NotBeNull();
    }

    #endregion
}
