using CepApi.Domain.Commands;
using CepApi.Domain.Entities;

namespace CepApi.Domain.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByEmail(string email);
        Task DeleteUser(Guid id);
    }
}
