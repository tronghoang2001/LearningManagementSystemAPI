using LearningManagementSystemAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class PrivateFilesDTO
    {
        public string FileType { get; set; }
        public string FileName { get; set; }
        public string Account { get; set; }
        public string UpdateDate { get; set; }
        public string Size { get; set; }
    }
}
