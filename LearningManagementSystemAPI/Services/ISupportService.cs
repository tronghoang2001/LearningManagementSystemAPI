using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public interface ISupportService
    {
        public Task<Support> CreateSupportAsync(CreateSupportDTO supportDTO);
    }
}
