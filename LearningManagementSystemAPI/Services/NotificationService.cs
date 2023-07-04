using AutoMapper;
using LearningManagementSystemAPI.Context;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LearningManagementSystemAPI.Services
{
    public class NotificationService : INotificationService
    {
        private readonly LmsContext _context;
        private readonly IMapper _mapper;
        public NotificationService(LmsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Notification> CreateNotificationAsync(CreateNotificationDTO notificationDTO)
        {
            var notification = _mapper.Map<Notification>(notificationDTO);
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
            return notification;
        }

        public async Task<List<NotificationDTO>> GetNotificationBySubjectIdAsync(int subjectId)
        {
            var notifications = await _context.Notifications
                .Include(n => n.Account)
                .Where(p => p.SubjectId == subjectId)
                .ToListAsync();
            return _mapper.Map<List<NotificationDTO>>(notifications);
        }
    }
}
