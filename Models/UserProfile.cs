using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace identity_rest_service.Models
{
    public class UserProfile
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }



        public AppUser AppUser { get; set; }

        public AgentProfile AgentProfile { get; set; }
        public int? AgentProfileID { get; set; }

        public UserType UserType { get; set; }
        public int UserTypeID { get; set; }
    }
}