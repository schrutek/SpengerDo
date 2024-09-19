using Spg.SpengerDo.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerDo.App.Account.Business
{
    public interface IUserRepository
    {
        User? Find(int userId);
        User? GetUserByUsername(string username);
    }
}
