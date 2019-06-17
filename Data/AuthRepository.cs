using System.Linq;
using System;
using System.Threading.Tasks;
using identity_rest_service.Helpers;
using identity_rest_service.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace identity_rest_service.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SignInManager<AppUser> _signManager;
        private readonly UserManager<AppUser> _userManager;
        public AuthRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
        }

        public async Task<AppUser> GetUserById(Guid id)
        {
            var user = await this._userManager.Users
             .Include(x => x.UserProfile)
             .ThenInclude(a => a.UserType)
             .Include(x => x.UserProfile)
             .ThenInclude(a => a.AgentProfile)
             .SingleAsync(x => x.Id == id);
            return user;
        }

        public async Task<AppUser> GetUserByName(string name)
        {
            var user = await this._userManager.Users
            .Include(x => x.UserProfile)
            .ThenInclude(a => a.UserType)
            .Include(x => x.UserProfile)
            .ThenInclude(a => a.AgentProfile)
            .SingleAsync(x => x.UserName == name);
            return user;
        }

        //future work for analytics API
        public async Task<PagedList<AppUser>> GetUsers(UserParams userParams)
        {
            var users = _userManager.Users.AsQueryable();
            return await PagedList<AppUser>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<(SignInResult SignInResult, AppUser Data)> Login(UserParams userParams)
        {
            var result = await _signManager.PasswordSignInAsync(userParams.UserName,
                 userParams.Password, false, false);

            return (SignInResult: result,
                    Data: result.Succeeded ? await this.GetUserByName(userParams.UserName)
                   : null);
        }
        public async Task<IdentityResult> Register(UserParams userParams)
        {
            var userProfile = new UserProfile
            {
                FirstName = userParams.FirstName,
                LastName = userParams.LastName,
                Address = userParams.Address
            };
            var user = new AppUser
            {
                UserName = userParams.UserName,
                Email = userParams.Email,
                PhoneNumber = userParams.PhoneNumber,
                CreationDate = DateTime.Now,
                UserProfile = userProfile
            };
            switch (userParams.UserType)
            {
                case "user":
                    user.UserProfile.UserTypeID = 1;
                    break;
                case "agent":
                    user.UserProfile.UserTypeID = 2;
                    break;
            }
            if (userParams.IsAgent)
            {
                var agentProfile = new AgentProfile
                {
                    OfficeAddress = userParams.OfficeAddress,
                    WebsiteUrl = userParams.WebsiteUrl,
                    License = userParams.License,
                    Vertified = userParams.Vertified
                };
                user.UserProfile.AgentProfile = agentProfile;
            }

            var result = await _userManager.CreateAsync(user, userParams.Password);
            return result;
        }

        public async Task<bool> UserExists(UserParams userParams)
        {
            if (!string.IsNullOrEmpty(userParams.Id))
                return await _userManager.FindByIdAsync(userParams.Id) != null;
            if (!string.IsNullOrEmpty(userParams.UserName))
                return await _userManager.FindByNameAsync(userParams.UserName) != null;
            return false;
        }
    }
}