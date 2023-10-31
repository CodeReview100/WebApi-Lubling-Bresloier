using Entities;
using Repository;

namespace Service
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //UserRepository userRepository = new UserRepository();

        public async Task<User> addUser(User user)
        {
            if  (await checkPassword( user.Password) < 2)
            {
                return  null;
            }
            return await _userRepository.addUser(user);
        }



        public async Task<User> getUser(string userName, string password)
        {
            return await _userRepository.getUser(userName, password);
        }


        public async Task<User> editUser(User userToUpdate)
        {

            return await _userRepository.editUser(userToUpdate);
        }

        private async Task<int> checkPassword(string password)
        {
            if (password != "")
            {
                var result = Zxcvbn.Core.EvaluatePassword(password);
                return  result.Score;
            }
            return  -1;
        }

    }
}