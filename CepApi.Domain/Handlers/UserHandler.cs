using CepApi.Domain.Commands;
using CepApi.Domain.Commands.Contracts;
using CepApi.Domain.Entities;
using CepApi.Domain.Handlers.Contracts;
using CepApi.Domain.Repositories.Contracts;
using CepApi.Domain.Shared.Utils;

namespace CepApi.Domain.Handlers
{
    public class UserHandler : IHandler<CreateUserCommand>, IHandler<UpdateUserCommand>, IHandler<LoginUserCommand>
    {
        public readonly IUserRepository _userRepository;

        public UserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ICommandResult> HandleAsync(CreateUserCommand command)
        {
            var passwordHash = PasswordHash.Hash(command.Password);
            var userExists = await _userRepository.GetUserByEmail(command.Email);

            if(userExists != null)
            {
                return new GenericCommandResult("This email is already in use", null, false);
            }

            var user = new User(command.Name, command.Email, passwordHash, command.Role);

            await _userRepository.CreateUser(user);

            return new GenericCommandResult("User created successfully", user, true);
        }

        public async Task<ICommandResult> HandleAsync(UpdateUserCommand command)
        {
            var passwordHash = PasswordHash.Hash(command.Password);
            var userExists = await _userRepository.GetUserById(command.Id);


            if (userExists != null)
            {
                userExists.UpdateName(command.Name);
                userExists.UpdateEmail(command.Email);
                userExists.UpdateRole(command.Role);
                userExists.UpdatePassword(passwordHash);

                await _userRepository.UpdateUser(userExists);

                return new GenericCommandResult("User created successfully", userExists, true);
            }

            return new GenericCommandResult("User not found", null, false);
        }

        public async Task<ICommandResult> HandleAsync(LoginUserCommand command)
        {
            var user = await _userRepository.GetUserByEmail(command.Email);

            if(user != null)
            {
                var passwordMatch = PasswordHash.PasswordMatch(command.Password, user.Password);

                if(passwordMatch)
                {
                    return new GenericCommandResult("User found", user, true);
                }
            }

            return new GenericCommandResult("Email/Password might be wrong", null, false);
        }
    }
}
