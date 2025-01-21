using Battleship.API.Model;
using Battleship.API.Data;

namespace Battleship.API.Repository;

public class UserRepository : IUserRepository 
{

    private readonly BattleshipContext _battleshipContext;

    public UserRepository (BattleshipContext battleshipContext) 
        => _battleshipContext = battleshipContext;
}