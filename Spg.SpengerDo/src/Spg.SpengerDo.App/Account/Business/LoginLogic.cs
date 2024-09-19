using Spg.SpengerDo.App.Model;
using Spg.SpengerDo.App.Presentation;

namespace Spg.SpengerDo.App.Account.Business
{
    public class LoginLogic : ILoginLogic
    {
        private readonly IUserRepository _userRepository;

        public LoginLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User LoginUser(LoginCredentials credentials)
        {
            User existingUser = _userRepository.GetUserByUsername(credentials.Username)
                ?? throw LoginException.FromNotFound();

            // TODO: Password check + hash and security stuff... Later!

            return existingUser;
        }
    }
}
