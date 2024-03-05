using CepApi.Domain.Commands.Contracts;

namespace CepApi.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand 
    {
        Task<ICommandResult> HandleAsync(T command);
    }
}
