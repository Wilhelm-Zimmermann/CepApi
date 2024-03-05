using CepApi.Domain.Commands;
using CepApi.Domain.Entities;

namespace CepApi.Domain.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<User> GetUserById(Guid id);
        Task DeleteUser(Guid id);
    }
}
