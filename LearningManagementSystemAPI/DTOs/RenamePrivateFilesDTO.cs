using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class RenamePrivateFilesDTO
    {
        [MaxLength(100)]
        public string FileName { get; set; }
    }
}
