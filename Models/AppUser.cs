using System;
using Microsoft.AspNetCore.Identity;

namespace identity_rest_service.Models
{
    public class AppUser: IdentityUser
    {
        public DateTime CreationDate { get; set; }
        public UserProfile UserProfile { get; set; }
        public int UserProfileID { get; set; }
    }
}