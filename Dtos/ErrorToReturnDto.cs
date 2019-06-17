using System.Collections.Generic;

namespace identity_rest_service.Dtos
{
    public class ErrorToReturnDto
    {
        public int ErrorCount { get; set; }

        public ICollection<string> ErrorList { get; set; }
    }
}