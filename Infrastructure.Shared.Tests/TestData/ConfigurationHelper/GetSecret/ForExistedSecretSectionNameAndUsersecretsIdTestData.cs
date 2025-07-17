namespace Infrastructure.Shared.Tests.TestData.ConfigurationHelper.GetSecret;

/// <summary>
/// Тестовые данные проверки метода получения секрета для существующего значения Название секции файла секретов для секрета
/// и Идентификатора секрета.
/// </summary>
public class ForExistedSecretSectionNameAndUsersecretsIdTestData : TheoryData<string, string>
{
    public ForExistedSecretSectionNameAndUsersecretsIdTestData()
    {
        Add("SK:ServiceApiKey", "705078df-8a7d-41c8-b13a-d9f26020eff8");
    }
}
