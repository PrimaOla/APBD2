using APBD2.Models.Users;
using System.Linq;

namespace APBD2.Services;

public class UserService
{
    private readonly List<User> _users = new();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }

    public User? GetById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }
}