using Spg.SpengerDo.App.Account.Business;
using Spg.SpengerDo.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerDo.App.Presentation
{
    public interface ILoginLogic
    {
        User LoginUser(LoginCredentials credentials);
    }
}
