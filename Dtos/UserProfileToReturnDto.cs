namespace identity_rest_service.Dtos
{
    public class UserProfileToReturnDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public AgentProfileToReturnDto AgentProfile { get; set; }

        public UserTypeToReturnDto UserType { get; set; }
    }
}
