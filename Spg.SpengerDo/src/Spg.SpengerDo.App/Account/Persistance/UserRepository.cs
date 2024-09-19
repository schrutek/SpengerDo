using Spg.SpengerDo.App.Account.Business;
using Spg.SpengerDo.App.Model;
using Spg.SpengerDo.App.Services;

namespace Spg.SpengerDo.App.Account.Persistance
{
    public class UserRepository : IUserRepository
    {
        private readonly SpengerDoDatabase _db;

        public UserRepository(SpengerDoDatabase db)
        {
            _db = db;
        }

        public User? Find(int userId)
        {
            return _db.Users.Find(userId);
        }

        public User? GetUserByUsername(string username)
        {
            return _db
                .Users
                .SingleOrDefault(u => u.EMail == username);
        }
    }
}
