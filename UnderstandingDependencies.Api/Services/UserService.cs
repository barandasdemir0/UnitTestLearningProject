using System.Diagnostics;
using UnderstandingDependencies.Api.Model;
using UnderstandingDependencies.Api.Repositories;

namespace UnderstandingDependencies.Api.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserService> _logger;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _logger = new Logger<UserService>(new LoggerFactory());
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        _logger.LogInformation("Retrieving all users");
        var stopWatch = Stopwatch.StartNew();
        try
        {
            var users = await _userRepository.GetAllAsync();
            return users;
        }
        finally 
        {

            stopWatch.Stop();
            _logger.LogInformation("All Users retrieved in {0} ms", stopWatch.ElapsedMilliseconds);
        }
    }
}
