using Battleship.API.Repository;
using Battleship.API.Model;

namespace Battleship.API.Service;

public class UserService : IUserService 
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository){
        _userRepository = userRepository; 
    }

}