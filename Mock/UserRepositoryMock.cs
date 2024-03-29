using System.Collections.Concurrent;
using System.Threading.Tasks;
using WebRTCServer.Interfaces;
using System.Linq;
using gizem_models;


namespace WebRTCServer.Mock
{
    public class UserRepositoryMock : IUserRepository
    {
        public UserRepositoryMock()
        {
            _users.TryAdd("1", new User() { UserId = "1", Name = "ahmet" });
            _users.TryAdd("2", new User() { UserId = "2", Name = "dhewy" });
        }

        private ConcurrentDictionary<string, User> _users = new ConcurrentDictionary<string, User>();
        public Task<User> getUserByName(string name)
        {
            return Task.FromResult(_users.Values.First(it => it.Name == name));
        }

        public Task<User> getUserById(string userid)
        {
            return Task.FromResult(_users[userid]);
        }
    }
}