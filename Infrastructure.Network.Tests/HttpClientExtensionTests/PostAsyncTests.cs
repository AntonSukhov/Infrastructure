using FluentAssertions;
using Infrastructure.Network.Enums;
using Infrastructure.Network.Extensions;
using Infrastructure.Network.Tests.HttpClientExtensionTests.Models;
using Infrastructure.Network.Tests.TestData.HttpClientExtension.PostAsync;
using System.Text.Json;

namespace Infrastructure.Network.Tests.HttpClientExtensionTests
{
    /// <summary>
    /// Тесты для проверки метода асинхронной отправки данных на сервер, заключенные в тело сообщения.
    /// </summary>
    public class PostAsyncTests
    {
        #region Методы

        /// <summary>
        /// Тест проверки метода асинхронной отправки данных на сервер, заключенные в тело сообщения для некорректных входных параметров.
        /// </summary>
        /// <param name="httpClient">Экземпляр <see cref="HttpClient"/>, используемый для отправки запроса.</param>
        /// <param name="url">URL-адрес, на который будет отправлен запрос.</param>
        /// <param name="inputObject">Объект, который будет сериализован и отправлен в запросе.</param>
        /// <param name="options">Настройки сериализации и десериализации объекта в JSON и обратно. Может быть null.</param>
        /// <param name="mediaType">Тип медиа-контента, по умолчанию <see cref="MediaType.Json"/>.</param>
        /// <returns>Асинхронная задача, представляющая результат выполнения теста.</returns>
        [Theory]
        [MemberData(nameof(ForIncorrectInputParamsTestData.GetTestData),
                    MemberType = typeof(ForIncorrectInputParamsTestData))]
        public async Task ForIncorrectInputParams(HttpClient httpClient, string url, PostDataModel? inputObject, JsonSerializerOptions? options, MediaType mediaType)
        {
            var func = async () => await HttpClientExtension.PostAsync<PostDataModel?, PostDataModel?>(httpClient, url, inputObject, options, mediaType);

            var exception = await func.Should().ThrowAsync<Exception>();

            exception.Match(p => p.Any(p1 => p1 is ArgumentException || p1 is ArgumentNullException || p1 is ArgumentOutOfRangeException || p1 is Exception));
        }

        /// <summary>
        /// Тест проверки метода асинхронной отправки данных на сервер, заключенные в тело сообщения для корректных входных параметров.
        /// </summary>
        /// <param name="httpClient">Экземпляр <see cref="HttpClient"/>, используемый для отправки запроса.</param>
        /// <param name="url">URL-адрес, на который будет отправлен запрос.</param>
        /// <param name="inputObject">Объект, который будет сериализован и отправлен в запросе.</param>
        /// <param name="options">Настройки сериализации и десериализации объекта в JSON и обратно. Может быть null.</param>
        /// <param name="mediaType">Тип медиа-контента, по умолчанию <see cref="MediaType.Json"/>.</param>
        /// <returns>Асинхронная задача, представляющая результат выполнения теста.</returns>
        [Theory]
        [MemberData(nameof(ForCorrectInputParamsTestData.GetTestData),
                    MemberType = typeof(ForCorrectInputParamsTestData))]
        public async Task ForCorrectInputParams(HttpClient httpClient, string url, PostDataModel inputObject, JsonSerializerOptions? options, MediaType mediaType)
        {
            var func = async () => await HttpClientExtension.PostAsync<PostDataModel, PostDataModel>(httpClient, url, inputObject, options, mediaType);

            var actual = await func();

            actual.Should().NotBeNull();
        }

        #endregion
    }
}
