using Battleship.API.Model;
using Battleship.API.Data;

namespace Battleship.API.Repository;

public class UserRepository : IUserRepository 
{

    private readonly BattleshipContext _battleshipContext;

    public UserRepository (BattleshipContext battleshipContext) 
        => _battleshipContext = battleshipContext;

    public async Task<User> CreateUser(User newUser){

        await _battleshipContext.Users.AddAsync(newUser);
        await _battleshipContext.SaveChangesAsync();
        return newUser;

    }

    public async Task<User> GetUserByUsername(string username)
    {
        return await _battleshipContext.Users.FindAsync(username);
    }

    public async Task<User> GetUserById(int id)
    {
        return await _battleshipContext.Users.FindAsync(id);
    }
}