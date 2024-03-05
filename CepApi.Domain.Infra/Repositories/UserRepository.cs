using CepApi.Domain.Commands;
using CepApi.Domain.Entities;
using CepApi.Domain.Infra.Context;
using CepApi.Domain.Repositories.Contracts;

namespace CepApi.Domain.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly MySqlContext _context;

        public UserRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public Task DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
