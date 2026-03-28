using Infrastructure.Networks.Services;

namespace Infrastructure.Networks.Tests.HttpClientServiceTests;

/// <summary>
/// Тесты для проверки метода генерации создания Http-клиента с настройками по умолчанию.
/// </summary>
public class CreateDefaultHttpClientTests
{
    /// <summary>
    /// Тест проверки метода создания Http-клиента с настройками по умолчанию без выброса исключений.
    /// </summary>
    [Fact]
    public void NotThrowException()
    {
        // Arrange
        var func = () => HttpClientService.CreateDefaultHttpClient();
    
        // Act 
        var result = func();
        
        // Assert
        Assert.NotNull(result);
    }
}
