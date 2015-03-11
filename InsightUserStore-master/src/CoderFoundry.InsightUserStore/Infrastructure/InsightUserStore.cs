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
            return _userData.InsertUserAsync(user);
        }

        public Task UpdateAsync(User user)
        {
            return _userData.DeleteUserAsync(user.Id);
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
            return Task.FromResult(user.PhoneNumber = phoneNumber);
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
            return Task.FromResult(user.PasswordHash = passwordHash);
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
            return _userData.InsertUserClaimAsync(new UserClaim { UserId = user.Id, ClaimType = claim.Type, ClaimValue = claim.Value });
        }

        public Task RemoveClaimAsync(User user, Claim claim)
        {
            return _userData.RemoveUserClaimAsync(user.Id, claim.Type);
        }

        public Task SetEmailAsync(User user, string email)
        {
            return Task.FromResult(user.Email = email);
        }

        public Task<string> GetEmailAsync(User user)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            return Task.FromResult(user.EmailConfirmed);
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            return Task.FromResult(user.EmailConfirmed = confirmed);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return _userData.FindUserByEmailAsync(email);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            return Task.FromResult(user.LockoutEndDate);
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            return Task.FromResult(user.LockoutEndDate = lockoutEnd);
        }

        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            return Task.FromResult(user.AccessFailedCount++);
        }

        public Task ResetAccessFailedCountAsync(User user)
        {
            return Task.FromResult(user.AccessFailedCount = 0);
        }

        public Task<int> GetAccessFailedCountAsync(User user)
        {
            return Task.FromResult(user.AccessFailedCount);
        }

        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return Task.FromResult(user.LockoutEnabled);
        }

        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            return Task.FromResult(user.IsLockedOut = enabled);
        }

        public Task SetSecurityStampAsync(User user, string stamp)
        {
            return Task.FromResult(user.SecurityStamp = stamp);
        }

        public Task<string> GetSecurityStampAsync(User user)
        {
            return Task.FromResult(user.SecurityStamp);
        }

        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            //help me
            return Task.FromResult(user.TwoFactorEnabled = enabled);
        }

        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return Task.FromResult(user.TwoFactorEnabled);
        }
    }
}