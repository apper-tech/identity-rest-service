using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace identity_rest_service.Models
{
    public class AgentProfile
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string OfficeAddress { get; set; }
        public string WebsiteUrl { get; set; }
        public string License { get; set; }
        public bool Vertified { get; set; }


        public UserProfile UserProfile { get; set; }
    }
}