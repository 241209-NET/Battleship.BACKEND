using Battleship.API.Repository;
using Battleship.API.Model;

namespace Battleship.API.Service;

public class UserService : IUserService 
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository){
        _userRepository = userRepository; 
    }

    public async Task<User> CreateUser(User newUser)
    {
        return await _userRepository.CreateUser(newUser);
    }

    public async Task<User>? GetUserById(string id)
    {
        var foundUser =
            await _userRepository.GetUserById(id)
            ?? throw new ArgumentException($"User with ID {id} not found.");
        return foundUser; 
    }

    public async Task<User>? GetUserByUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            throw new ArgumentException("Username cannot be null or empty.", nameof(username));
        }
        var foundUser =
            await _userRepository.GetUserByUsername(username)!
            ?? throw new InvalidOperationException($"User with username '{username}' not found.");
        return foundUser;
    }

    // public User GetUserByUsername(string username)
    // {
    //     if (string.IsNullOrWhiteSpace(username))
    //     {
    //         throw new ArgumentException("Username cannot be null or empty.", nameof(username));
    //     }
    //     var foundUser =
    //          _userRepository.GetUserByUsername(username)!
    //         ?? throw new InvalidOperationException($"User with username '{username}' not found.");
    //     return foundUser;
    // }

    public async Task<IEnumerable<User>> GetAllUsers(){
        return await _userRepository.GetAllUsers();
    }

}