using CepApi.Domain.Commands;
using CepApi.Domain.Commands.Contracts;
using CepApi.Domain.Handlers.Contracts;

namespace CepApi.Domain.Handlers
{
    public class UserHandler : IHandler<CreateUserCommand>
    {
        public async Task<ICommandResult> HandleAsync(CreateUserCommand command)
        {
            return new GenericCommandResult("User created successfully", null, true);
        }
    }
}
