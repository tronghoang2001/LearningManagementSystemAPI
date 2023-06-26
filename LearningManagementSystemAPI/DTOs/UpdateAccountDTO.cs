using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class UpdateAccountDTO
    {
        public string Code { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public Boolean Gender { get; set; }
        [MaxLength(100)]
        public string Avatar { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public int Status { get; set; }
        public int RoleId { get; set; }
    }
}
