using Infrastructure.Networks.Enums;
using Infrastructure.Networks.Services;
using Infrastructure.Networks.Tests.HttpClientExtensionTests.Models;
using System.Text.Json;

namespace Infrastructure.Networks.Tests.TestData.HttpClientExtension.PostAsync
{
    /// <summary>
    /// Тестовые данные проверки метод асинхронной отправки данных на сервер, заключенные в тело сообщения для корректных входных параметров.
    /// </summary>
    public static class ForCorrectInputParamsTestData
    {
        #region Методы

        public static TheoryData<HttpClient, string, PostDataModel, JsonSerializerOptions?, MediaType> GetTestData()
        {
            var url = "https://jsonplaceholder.typicode.com/posts";
            var postDataModel = new PostDataModel { Title = "foo", Body = "bar", UserId = 1 };
            var httpClient = HttpClientService.CreateDefaultHttpClient();

            return new TheoryData<HttpClient, string, PostDataModel, JsonSerializerOptions?, MediaType>
            {
                { httpClient, url, postDataModel, JsonSerializerOptions.Default, MediaType.Json },
            };
        }

        #endregion
    }
}
