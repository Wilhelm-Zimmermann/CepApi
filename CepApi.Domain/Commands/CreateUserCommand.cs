using CepApi.Domain.Commands.Contracts;

namespace CepApi.Domain.Commands
{
    public class CreateUserCommand : ICommand
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
    }
}
