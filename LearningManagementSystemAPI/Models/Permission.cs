using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LearningManagementSystemAPI.Models
{
    [Table("Permission")]
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<PermissionRole> PermissionRoles { get; set; }
    }
}
