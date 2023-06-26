using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class UserUpdateAccountDTO
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public Boolean Gender { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
    }
}
