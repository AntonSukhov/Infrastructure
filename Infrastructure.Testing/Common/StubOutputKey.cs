namespace Infrastructure.Testing.Common;

/// <summary>
/// Ключ для идентификации выходных данных заглушек.
/// </summary>
/// <param name="MethodName">Имя тестируемого метода.</param>
/// <param name="SequenceNumber">Порядковый номер данных в словаре.</param>
public record StubOutputKey(string MethodName, int SequenceNumber)
{ 
    public override string ToString() => $"{MethodName}№{SequenceNumber}";
}
