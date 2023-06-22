using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class CreateAccountDTO
    {
        public string Code { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public Boolean Gender { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        [MaxLength(30)]
        public string RoleName { get; set; }
        public int RoleId { get; set; }
    }
}
