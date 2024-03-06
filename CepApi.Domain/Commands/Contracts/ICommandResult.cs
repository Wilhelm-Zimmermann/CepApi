namespace CepApi.Domain.Commands.Contracts
{
    public interface ICommandResult
    {
        string Message { get; }
        object Data { get; }
        bool Success { get; }
    }
}
