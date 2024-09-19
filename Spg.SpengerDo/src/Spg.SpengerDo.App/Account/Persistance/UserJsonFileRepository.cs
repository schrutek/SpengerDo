using Spg.SpengerDo.App.Account.Business;
using Spg.SpengerDo.App.Model;

namespace Spg.SpengerDo.App.Account.Persistance
{
    public class UserJsonFileRepository : IUserRepository
    {
        public User? Find(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
