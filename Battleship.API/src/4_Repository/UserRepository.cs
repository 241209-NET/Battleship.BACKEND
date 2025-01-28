using Battleship.API.Model;
using Battleship.API.Data;
using Microsoft.EntityFrameworkCore;

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

    public async Task<User> GetUserById(string id)
    {
        return await _battleshipContext.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _battleshipContext.Users.ToListAsync();
    }

}