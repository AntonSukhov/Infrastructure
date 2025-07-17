namespace Infrastructure.Shared.Tests.TestData.ConfigurationHelper.GetSecret;

/// <summary>
/// Тестовые данные проверки метода получения секрета для некорректных значений Название секции файла секретов для секрета
/// или Идентификатора секрета.
/// </summary>
public class ForIncorrectInputParamsTestData : TheoryData<string, string>
{
    public ForIncorrectInputParamsTestData()
    {
        Add(string.Empty, Guid.NewGuid().ToString());
        Add("SK:ServiceApiKey", string.Empty);
        Add(string.Empty, string.Empty);
    }
}
