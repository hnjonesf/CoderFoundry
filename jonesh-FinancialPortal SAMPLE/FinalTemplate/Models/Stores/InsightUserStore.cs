using CoderFoundry.InsightUserStore.DataAccess;
using CoderFoundry.InsightUserStore.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoderFoundry.InsightUserStore.Infrastructure
{
    public class InsightUserStore :
        IUserPhoneNumberStore<AppUser, int>,
        IUserPasswordStore<AppUser, int>,
        IUserLoginStore<AppUser, int>,
        IUserRoleStore<AppUser, int>,
        IUserClaimStore<AppUser, int>,
        IUserEmailStore<AppUser, int>,
        IUserLockoutStore<AppUser, int>,
        IUserSecurityStampStore<AppUser, int>,
        IUserTwoFactorStore<AppUser, int>
    {
        private readonly IUserDataAccess _userData;

        public InsightUserStore(IUserDataAccess userData)
        {
            _userData = userData;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(AppUser user)
        {
            return _userData.InsertUserAsync(user);
        }

        public Task UpdateAsync(AppUser user)
        {
            return _userData.UpdateUserAsync(user);
        }

        public Task DeleteAsync(AppUser user)
        {
            return _userData.DeleteUserAsync(user.Id);
        }

        public Task<AppUser> FindByIdAsync(int userId)
        {
            return _userData.SelectUserAsync(userId);
        }

        public Task<AppUser> FindByNameAsync(string userName)
        {
            return _userData.FindUserByUserNameAsync(userName);
        }

        public Task SetPhoneNumberAsync(AppUser user, string phoneNumber)
        {

            return Task.FromResult(user.PhoneNumber = phoneNumber);
        }

        public Task<string> GetPhoneNumberAsync(AppUser user)
        {
            return Task.FromResult(user.PhoneNumber);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(AppUser user)
        {
            return Task.FromResult(user.PhoneNumberConfirmed);
        }

        public Task SetPhoneNumberConfirmedAsync(AppUser user, bool confirmed)
        {
            
            return Task.FromResult(user.PhoneNumberConfirmed = confirmed );
        }

        public Task SetPasswordHashAsync(AppUser user, string passwordHash)
        {
            return Task.FromResult(user.PasswordHash = passwordHash);
        }

        public Task<string> GetPasswordHashAsync(AppUser user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(AppUser user)
        {
            return Task.FromResult(String.IsNullOrEmpty(user.PasswordHash));
        }

        public Task AddLoginAsync(AppUser user, UserLoginInfo login)
        {
            UserLogin userLogin = new UserLogin();
            userLogin.UserId = user.Id;
            userLogin.LoginProvider = login.LoginProvider;
            userLogin.ProviderKey = login.ProviderKey;
            return _userData.InsertUserLoginAsync(userLogin);
        }

        public Task RemoveLoginAsync(AppUser user, UserLoginInfo login)
        {
            UserLogin userLogin = new UserLogin();
            userLogin.UserId = user.Id;
            userLogin.LoginProvider = login.LoginProvider;
            userLogin.ProviderKey = login.ProviderKey;
            return _userData.DeleteUserLoginAsync(userLogin);
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(AppUser user)
        {
            IList<UserLoginInfo> loginInfos = new List<UserLoginInfo>();
            var logins = await _userData.GetLoginsForUserAsync(user.Id);
            

            foreach(var login in logins)
            {
                loginInfos.Add(new UserLoginInfo(login.LoginProvider, login.ProviderKey));
            }
            
            return loginInfos; 
        }

        public Task<AppUser> FindAsync(UserLoginInfo login)
        {
            return _userData.FindUserByLoginAsync(login.LoginProvider, login.ProviderKey);
        }

        public Task AddToRoleAsync(AppUser user, string roleName)
        {
            return _userData.AddUserToRoleAsync(user.Id, roleName);
        }

        public Task RemoveFromRoleAsync(AppUser user, string roleName)
        {
            return _userData.RemoveUserFromRoleAsync(user.Id, roleName);
        }

        public Task<IList<string>> GetRolesAsync(AppUser user)
        {
            return _userData.GetRolesForUserAsync(user.Id);
        }

        public Task<bool> IsInRoleAsync(AppUser user, string roleName)
        {
            return _userData.IsUserInRoleAsync(user.Id, roleName);
        }

        public async Task<IList<Claim>> GetClaimsAsync(AppUser user)
        {
            var userClaims = await _userData.GetUserClaimsAsync(user.Id);

            var claims = userClaims.Select(x => new Claim(x.ClaimType, x.ClaimValue)).ToList();

            if (user.Name != null)
            {
                claims.Add(new Claim(ClaimTypes.GivenName, user.Name));
            }

            return claims; 
          
        }

        public async Task AddClaimAsync(AppUser user, Claim claim)
        {
            await _userData.InsertUserClaimAsync(new UserClaim()
            {
                UserId = user.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            });
        }

        public Task RemoveClaimAsync(AppUser user, Claim claim)
        {
            return _userData.RemoveUserClaimAsync(user.Id, claim.Type);
        }

        public Task SetEmailAsync(AppUser user, string email)
        {
            return Task.FromResult(user.Email = email);
        }

        public Task<string> GetEmailAsync(AppUser user)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(AppUser user)
        {
            return Task.FromResult(user.EmailConfirmed);
        }

        public Task SetEmailConfirmedAsync(AppUser user, bool confirmed)
        {
            user.EmailConfirmed = confirmed;
            return Task.FromResult(user.EmailConfirmed = confirmed);
        }

        public Task<AppUser> FindByEmailAsync(string email)
        {
            return _userData.FindUserByEmailAsync(email);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(AppUser user)
        {
            return Task.FromResult(user.LockoutEndDate);
        }

        public Task SetLockoutEndDateAsync(AppUser user, DateTimeOffset lockoutEnd)
        {
            
            return Task.FromResult(user.LockoutEndDate = lockoutEnd);
        }

        public Task<int> IncrementAccessFailedCountAsync(AppUser user)
        {
            
            return Task.FromResult(user.AccessFailedCount ++); 
        }

        public Task ResetAccessFailedCountAsync(AppUser user)
        {
            return Task.FromResult(user.AccessFailedCount = 0);
        }

        public Task<int> GetAccessFailedCountAsync(AppUser user)
        {
            return Task.FromResult(user.AccessFailedCount);
        }

        public Task<bool> GetLockoutEnabledAsync(AppUser user)
        {
            return Task.FromResult(user.LockoutEnabled);
        }

        public Task SetLockoutEnabledAsync(AppUser user, bool enabled)
        {

            return Task.FromResult(user.LockoutEnabled = enabled);
        }

        public Task SetSecurityStampAsync(AppUser user, string stamp)
        {

            return Task.FromResult(user.SecurityStamp = stamp);
        }

        public Task<string> GetSecurityStampAsync(AppUser user)
        {
            return Task.FromResult(user.SecurityStamp);
        }

        public Task SetTwoFactorEnabledAsync(AppUser user, bool enabled)
        {

            return Task.FromResult(user.TwoFactorEnabled = enabled);
        }

        public Task<bool> GetTwoFactorEnabledAsync(AppUser user)
        {
            return Task.FromResult(user.TwoFactorEnabled);
        }
    }
}