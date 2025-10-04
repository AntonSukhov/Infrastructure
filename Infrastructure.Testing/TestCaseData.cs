namespace Infrastructure.Testing;

/// <summary>
/// Данные для выполнения теста.
/// </summary>
/// <typeparam name="TIn">Тип входных данных.</typeparam>
/// <typeparam name="TOut">Тип выходных данных.</typeparam>
public class TestCaseData<TIn, TOut>
{
    #region Свойства

    /// <summary>
    /// Получает или задает порядковый номер тестового набора данных.
    /// </summary>
    public required int SerialNumber { get; set; }

    /// <summary>
    /// Получает или задает входные данные для выполнения теста.
    /// </summary>
    public required TIn InputData { get; set; }

    /// <summary>
    /// Получает или задает выходные данные для выполнения теста.
    /// </summary>
    public required TOut OutputData { get; set; }

    /// <summary>
    /// Получает или задает описание теста, с которым связан тестовый набор данных.
    /// </summary>
    public required string Description { get; set; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="TestCaseData{TIn, TOut}"/> без установки значений свойств.
    /// </summary>
    public TestCaseData() { }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="TestCaseData{TIn, TOut}"/> с указанными данными для теста.
    /// </summary>
    /// <param name="serialNumber">Порядковый номер тестового набора данных.</param>
    /// <param name="inputData">Входные данные для выполнения теста.</param>
    /// <param name="outputData">Выходные данные для выполнения теста.</param>
    /// <param name="description">Описание теста, с которым связан тестовый набор данных.</param>
    public TestCaseData(int serialNumber, TIn inputData, TOut outputData, string description)
    {
        ArgumentNullException.ThrowIfNull(inputData);
        ArgumentNullException.ThrowIfNull(outputData);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);

        SerialNumber = serialNumber;
        InputData = inputData;
        OutputData = outputData;
        Description = description;
    }

    #endregion
}
