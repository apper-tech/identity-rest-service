using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using identity_rest_service.Helpers;
using identity_rest_service.Models;
using Microsoft.AspNetCore.Identity;

namespace identity_rest_service.Data
{
    public interface IAuthRepository
    {
        Task<PagedList<AppUser>> GetUsers(UserParams userParams);
        Task<IdentityResult> Register(UserParams userParams);
        Task<(SignInResult SignInResult, AppUser Data)> Login(UserParams userParams);
        Task<bool> UserExists(UserParams userParams);
        Task<AppUser> GetUserById(Guid id);
        Task<AppUser> GetUserByName(string name);

    }
}