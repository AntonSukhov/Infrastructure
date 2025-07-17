namespace Infrastructure.Shared.Tests.TestData.ConfigurationHelper.GetSecret;

/// <summary>
/// Тестовые данные проверки метода получения секрета для несуществующего значения Название секции файла секретов для секрета
/// или Идентификатора секрета.
/// </summary>
public class ForNotExistedSecretSectionNameAndUsersecretsIdTestData : TheoryData<string, string>
{
    public ForNotExistedSecretSectionNameAndUsersecretsIdTestData()
    {
        Add(Guid.NewGuid().ToString(), "705078df-8a7d-41c8-b13a-d9f26020eff8");
        Add("SK:ServiceApiKey", Guid.NewGuid().ToString());
        Add(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
    }
}
