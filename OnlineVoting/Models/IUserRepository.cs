using System.Collections.Generic;
using OnlineVoting.Models;

public interface IUserRepository
{
    IEnumerable<User> GetAllUsers();
    User GetUserById(int id);
    void AddUser(User user);
    void UpdateUser(User user);
}
