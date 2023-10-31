using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> addUser(User user);
        Task<User> editUser(User userToUpdate);
        Task<User> getUser(string userName, string password);
    }
}