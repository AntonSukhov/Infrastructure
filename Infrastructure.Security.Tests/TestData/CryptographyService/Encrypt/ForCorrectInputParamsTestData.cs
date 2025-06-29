namespace Infrastructure.Security.Tests.TestData.CryptographyService.Encrypt;

/// <summary>
/// Тестовые данные проверки метода шифрования строки с использованием AES для корректных входных параметров.
/// </summary>
public class ForCorrectInputParamsTestData : TheoryData<string, string>
{
    #region Конструкторы

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public ForCorrectInputParamsTestData()
    {       
        Add("text1177", "ZWbw+SVetnbgtsBvc5p6POkDHSWsgO+bN0qtWjnXBbE=");
        Add("Привет_мир!!!", "O8HYLKgJ6QS+FKZIhvyeN4KTDg+5Ivy+YUnz1U2rR8Q=");
        Add("64", "mLbWrlNTQ6mqTeZicO+23ahrU3RyM3fehJz6IvdyTwI=");
    }

    #endregion
}
