using Entities;

namespace Service
{
    public interface IUserService
    {
        User addUser(User user);
        User editUser(User userToUpdate);
        User getUser(string userName, string password);
    }
}