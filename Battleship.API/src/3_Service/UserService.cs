using Battleship.API.Repository;
using Battleship.API.Model;
using Battleship.API.DTO;

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

    public async Task<UserScoreDTO> UpdateUserScore(string userId, int wins, int losses)
    {
        User updateUser = await _userRepository.UpdateUserScore(userId, wins, losses); 
        UserScoreDTO updateUserScore = new(){Wins = updateUser.NumWins, Losses = updateUser.NumLosses};
        return updateUserScore; 
    }

    public async Task<IEnumerable<UserScoreDTO>> GetAllUserScores()
    {
        var dtoList = new List<UserScoreDTO>(); 
        var userList = await _userRepository.GetAllUsers();
        foreach(var user in userList){
            UserScoreDTO score = new(){AccountName = user.AccountName, Wins = user.NumWins, Losses = user.NumLosses};
            dtoList.Add(score); 
        }

        return dtoList; 
    }

}