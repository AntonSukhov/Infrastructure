namespace Infrastructure.Security.Tests.TestData.CryptographyService.Encrypt;

/// <summary>
/// Тестовые данные проверки метода шифрования строки с использованием AES для некорректных входных параметров.
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
        Add("text1177", string.Empty);
        Add("64", "  ");
        Add("jk19_1", "s+L2PasBAhIuN9kY0GunpcIHSYD6jafloAVW/RbSCikhzo/E1JTA0KwS5pNwdIb3xjpb7szdrkZnsdK9KbHiew==");
    }

    #endregion
}
