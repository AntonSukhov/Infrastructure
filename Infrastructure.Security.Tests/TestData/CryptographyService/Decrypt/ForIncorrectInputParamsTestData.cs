namespace Infrastructure.Security.Tests.TestData.CryptographyService.Decrypt;

/// <summary>
/// Тестовые данные проверки метода дешифрования строки с использованием AES для некорректных входных параметров.
/// </summary>
public class ForIncorrectInputParamsTestData : TheoryData<string, string>
{
    #region Конструкторы

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public ForIncorrectInputParamsTestData()
    {
        Add(string.Empty, "ZWbw+SVetnbgtsBvc5p6POkDHSWsgO+bN0qtWjnXBbE=");
        Add(" ", "ZWbw+SVetnbgtsBvc5p6POkDHSWsgO+bN0qtWjnXBbE=");
        Add("dNBscUshBTryTCGZ2UNMNmwsw4vhEkr98Kct4GlTSdg/M51kHzSr51s1rK7UKG3q", string.Empty);
        Add("g7Xl/mKRAUvmVyxaXZvyt1cdBkkB66zi1XUv+4BmtrM=", "  ");
        Add("g7Xl/mKRAUvmVyxaXZvyt1cdBkkB66zi1XUv+4BmtrM=", "s+L2PasBAhIuN9kY0GunpcIHSYD6jafloAVW/RbSCikhzo/E1JTA0KwS5pNwdIb3xjpb7szdrkZnsdK9KbHiew==");
    }

    #endregion
}
