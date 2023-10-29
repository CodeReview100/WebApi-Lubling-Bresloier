using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        User addUser(User user);
        User editUser(User userToUpdate);
        User getUser(string userName, string password);
    }
}