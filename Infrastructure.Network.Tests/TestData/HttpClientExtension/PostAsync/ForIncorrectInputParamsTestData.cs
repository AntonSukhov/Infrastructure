using Infrastructure.Network.Enums;
using Infrastructure.Network.Services;
using Infrastructure.Network.Tests.HttpClientExtensionTests.Models;
using System.Text.Json;

namespace Infrastructure.Network.Tests.TestData.HttpClientExtension.PostAsync
{
    /// <summary>
    /// Тестовые данные проверки метод асинхронной отправки данных на сервер, заключенные в тело сообщения для некорректных входных параметров.
    /// </summary>
    public class ForIncorrectInputParamsTestData
    {
        #region Методы

        public static TheoryData<HttpClient, string, PostDataModel?, JsonSerializerOptions?, MediaType> GetTestData()
        {
            var url = "api_url";
            var postDataModel = new PostDataModel { Title = "foo", Body = "bar", UserId = 1 };
            var httpClient = HttpClientService.CreateDefaultHttpClient();

            return new TheoryData<HttpClient, string, PostDataModel?, JsonSerializerOptions?, MediaType>
            {
                { httpClient, string.Empty, postDataModel, JsonSerializerOptions.Default, MediaType.Json },
                { httpClient, " ", postDataModel, JsonSerializerOptions.Default, MediaType.Json },
                { httpClient, url, postDataModel, JsonSerializerOptions.Default, (MediaType)int.MaxValue },
                { httpClient, url, null, JsonSerializerOptions.Default, MediaType.Json }
            };
        }

        #endregion
    }
}
