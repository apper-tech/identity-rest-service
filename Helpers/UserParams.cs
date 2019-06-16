using System;

namespace identity_rest_service.Helpers
{
    public class UserParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value < MaxPageSize ? value : MaxPageSize; }
        }
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string UserType { get; set; }

        public bool IsAgent { get; set; }

        public string OfficeAddress { get; set; }

        public string WebsiteUrl { get; set; }

        public string License { get; set; }

        public bool Vertified { get; set; }

    }
}