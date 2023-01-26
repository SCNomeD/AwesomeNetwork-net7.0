using AwesomeNetwork.Models.Users;
using AwesomeNetwork.ViewModels.Account;
using Microsoft.AspNetCore.Identity;

namespace AwesomeNetwork.Checkers
{
    public static class AccountChecker
    {
        public static PasswordVerificationResult CheckPassword(UserManager<User> _userManager, LoginViewModel model)
        {
            PasswordVerificationResult result;

            try
            {
                var SingleUser = _userManager.Users.SingleOrDefault(x => x.Email == model.Email);
                result = _userManager.PasswordHasher.VerifyHashedPassword(SingleUser, SingleUser.PasswordHash, model.Password);
            }
            catch (System.Exception)
            {

                return PasswordVerificationResult.Failed;
            }
            return result;
        }
    }
}
