using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public interface INotificationService
    {
        public Task<List<NotificationDTO>> GetNotificationBySubjectIdAsync(int subjectId);

        public Task<Notification> CreateNotificationAsync(CreateNotificationDTO notificationDTO);
    }
}
