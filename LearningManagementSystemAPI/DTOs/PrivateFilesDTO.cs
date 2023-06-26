using LearningManagementSystemAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementSystemAPI.DTOs
{
    public class PrivateFilesDTO
    {
        public int PrivateFilesId { get; set; }
        public string FileName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public double Size { get; set; }
        public string Account { get; set; }
    }
}
