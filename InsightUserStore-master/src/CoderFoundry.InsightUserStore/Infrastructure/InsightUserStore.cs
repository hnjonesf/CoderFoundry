using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CoderFoundry.InsightUserStore.DataAccess;
using CoderFoundry.InsightUserStore.Models;
using Microsoft.AspNet.Identity;

namespace CoderFoundry.InsightUserStore.Infrastructure
{
    public class InsightUserStore :
        IUserPhoneNumberStore<User, int>,
        IUserPasswordStore<User, int>, 
        IUserLoginStore<User, int>,
        IUserRoleStore<User, int>, 
        IUserClaimStore<User, int>, 
        IUserEmailStore<User, int>,
        IUserLockoutStore<User,int>,
        IUserSecurityStampStore<User,int>,
        IUserTwoFactorStore<User,int>
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

        public Task CreateAsync(User user)
        {
            return _userData.InsertUserAsync(user.Id);
            //help

        }

        public Task UpdateAsync(User user)
        {
            return _userData.DeleteUserAsync(user.Id);
            //nope
        }

        public Task DeleteAsync(User user)
        {
            return _userData.DeleteUserAsync(user.Id);
        }

        public Task<User> FindByIdAsync(int userId)
        {
            return _userData.SelectUserAsync(userId);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return _userData.FindUserByUserNameAsync(userName);
        }

        public Task SetPhoneNumberAsync(User user, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPhoneNumberAsync(User user)
        {
            return Task.FromResult(user.PhoneNumber);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(User user)
        {
            return Task.FromResult(user.PhoneNumberConfirmed);
        }

        public Task SetPhoneNumberConfirmedAsync(User user, bool confirmed)
        {
            return Task.FromResult(user.PhoneNumberConfirmed = confirmed);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(!string.IsNullOrWhiteSpace(user.PasswordHash));
        }

        public Task AddLoginAsync(User user, UserLoginInfo login)
        {
            var userLogin = new UserLogin
            {
                UserId = user.Id,
                LoginProvider = login.LoginProvider,
                ProviderKey = login.ProviderKey
            };

            return _userData.InsertUserLoginAsync(userLogin);
        }

        public Task RemoveLoginAsync(User user, UserLoginInfo login)
        {
            var userLogin = new UserLogin
            {
                UserId = user.Id,
                LoginProvider = login.LoginProvider,
                ProviderKey = login.ProviderKey
            };

            return _userData.DeleteUserLoginAsync(userLogin);
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(User user)
        {
            var logins = await _userData.GetLoginsForUserAsync(user.Id);
            var loginList = new List<UserLoginInfo>(user.Id);
            foreach (var item in logins)
            {
                loginList.Add(new UserLoginInfo(item.LoginProvider, item.ProviderKey));
            }
            return loginList; 
        }

        public Task<User> FindAsync(UserLoginInfo login)
        {
            return _userData.FindUserByLoginAsync(login.LoginProvider, login.ProviderKey);
        }

        public Task AddToRoleAsync(User user, string roleName)
        {
            return _userData.AddUserToRoleAsync(user.Id, roleName);
        }

        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            return _userData.RemoveUserFromRoleAsync(user.Id, roleName);
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            return _userData.GetRolesForUserAsync(user.Id);
        }

        public Task<bool> IsInRoleAsync(User user, string roleName)
        {
            return _userData.IsUserInRoleAsync(user.Id, roleName);
        }

        public async Task<IList<Claim>> GetClaimsAsync(User user)
        {
            //build a list of claims
            var userClaims = await _userData.GetUserClaimsAsync(user.Id);
            var claims = new List<Claim>();
            foreach (var item in userClaims)
            {
                claims.Add(new Claim(item.ClaimType, item.ClaimValue));
            }

            //add any app-specific claims
            if (user.Name != null) 
            {
                claims.Add(new Claim(ClaimTypes.GivenName, user.Name));
            } 
            
            return claims; 
        }

        public Task AddClaimAsync(User user, Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimAsync(User user, Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(User user, string email)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetSecurityStampAsync(User user, string stamp)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSecurityStampAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}