using CepApi.Domain.Commands.Contracts;

namespace CepApi.Domain.Commands
{
    public class LoginUserCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
