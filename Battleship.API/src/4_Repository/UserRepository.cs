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

    public User GetUserByUsername(string username)
    {
        return _battleshipContext.Users.FirstOrDefault(u => u.UserName == username);
        //Where(u => u.UserName.Contains(username));
        //o => o.Id == id
    }

    public async Task<User> GetUserById(int id)
    {
        return await _battleshipContext.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _battleshipContext.Users.ToListAsync();
    }

}