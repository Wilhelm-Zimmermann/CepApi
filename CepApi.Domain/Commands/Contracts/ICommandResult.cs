namespace CepApi.Domain.Commands.Contracts
{
    public interface ICommandResult
    {
        string Message { get; }
        string Data { get; }
        bool Success { get; }
    }
}
