using CepApi.Domain.Commands.Contracts;

namespace CepApi.Domain.Commands
{
    public class LoginUserCommand : ICommand
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
