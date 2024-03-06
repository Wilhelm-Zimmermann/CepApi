using CepApi.Domain.Entities;
using CepApi.Domain.Infra.Context;
using CepApi.Domain.Queries;
using CepApi.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CepApi.Domain.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly MySqlContext _context;

        public UserRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(UserQueries.GetUserById(id));
        }

        public async Task<User> GetUserByEmail(string email) 
        {
            return await _context.Users.FirstOrDefaultAsync(UserQueries.GetUserByEmail(email));
        }

        public async Task CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(Guid id)
        {
            var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
