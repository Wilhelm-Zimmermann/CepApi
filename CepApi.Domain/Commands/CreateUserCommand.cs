﻿using CepApi.Domain.Commands.Contracts;

namespace CepApi.Domain.Commands
{
    public class CreateUserCommand : ICommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
