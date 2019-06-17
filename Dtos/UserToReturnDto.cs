using System;

namespace identity_rest_service.Dtos
{
    public class UserToReturnDto
    {

        public DateTime CreationDate { get; set; }
        public UserProfileToReturnDto UserProfile { get; set; }
    }
}