using Infrastructure.Networks.Enums;
using Infrastructure.Networks.Tests.HttpClientExtensionTests.Models;
using System.Text.Json;

namespace Infrastructure.Networks.Tests.TestData.HttpClientExtension.PostAsync
{
    /// <summary>
    /// Тестовые данные проверки метод асинхронной отправки данных на сервер, заключенные в тело сообщения для некорректных входных параметров.
    /// </summary>
    public static class ForIncorrectInputParamsTestData
    {
        public static TheoryData<HttpClient, string, PostDataModel?, JsonSerializerOptions?, MediaType> GetTestData()
        {
            var url = "api_url";
            var postDataModel = new PostDataModel { Title = "foo", Body = "bar", UserId = 1 };
            var httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(10), // Короткий таймаут для тестов
                DefaultRequestHeaders =
                {
                    {"User-Agent", "TestClient/1.0"},
                    {"Accept", "application/json"}
                }
            };

            return new TheoryData<HttpClient, string, PostDataModel?, JsonSerializerOptions?, MediaType>
            {
                { httpClient, string.Empty, postDataModel, JsonSerializerOptions.Default, MediaType.Json },
                { httpClient, " ", postDataModel, JsonSerializerOptions.Default, MediaType.Json },
                { httpClient, url, postDataModel, JsonSerializerOptions.Default, (MediaType)int.MaxValue },
                { httpClient, url, null, JsonSerializerOptions.Default, MediaType.Json }
            };
        }
    }
}
