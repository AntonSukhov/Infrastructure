namespace Infrastructure.Security.Tests.TestData.CryptographyService.Decrypt;

/// <summary>
/// Тестовые данные проверки метода дешифрования строки с использованием AES для корректных входных параметров.
/// </summary>
public class ForCorrectInputParamsTestData : TheoryData<string, string>
{
    #region Конструкторы

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public ForCorrectInputParamsTestData()
    {       
        Add("arkznDPAeHXqx8TNL4dZqbXUJl4L66LLL2+SXSgfuNM=", "ZWbw+SVetnbgtsBvc5p6POkDHSWsgO+bN0qtWjnXBbE=");
        Add("dNBscUshBTryTCGZ2UNMNmwsw4vhEkr98Kct4GlTSdg/M51kHzSr51s1rK7UKG3q", "O8HYLKgJ6QS+FKZIhvyeN4KTDg+5Ivy+YUnz1U2rR8Q=");
        Add("g7Xl/mKRAUvmVyxaXZvyt1cdBkkB66zi1XUv+4BmtrM=", "mLbWrlNTQ6mqTeZicO+23ahrU3RyM3fehJz6IvdyTwI=");
    }

    #endregion
}
