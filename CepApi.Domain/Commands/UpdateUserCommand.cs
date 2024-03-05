using CepApi.Domain.Commands.Contracts;
using System.Text.Json.Serialization;

namespace CepApi.Domain.Commands
{
    public class UpdateUserCommand : ICommand
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
