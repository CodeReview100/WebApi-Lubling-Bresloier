using Entities;
using System.Text.Json;

namespace Repository
{
    public class UserRepository
    {
        string path = "M:/WebApi/ApiEx01/API/wwwroot/users.txt";
     public User addUser(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(path).Count();
            user.UserId = numberOfUsers + 1;
            //var result = Zxcvbn.Core.EvaluatePassword(user.Password);
            //if (result.Score <= 2)
            //{
            //    return BadRequest();
            //}
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(path, userJson + Environment.NewLine);
            return user;

        }



        public User getUser(string userName, string password)
        {


            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserName == userName && user.Password == password)
                        return user;
                }
            }
            return null;
        }

        public User editUser(User userToUpdate)
        {

            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == userToUpdate.UserId)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(path);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(path, text);
            }


            return userToUpdate;
        }


    }
}