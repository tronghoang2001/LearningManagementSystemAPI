using AutoMapper;
using LearningManagementSystemAPI.Context;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystemAPI.Services
{
    public class TopicService : ITopicService
    {
        private readonly LmsContext _context;
        private readonly IMapper _mapper;
        public TopicService(LmsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Topic> CreateTopicAsync(CreateTopicDTO topicDTO)
        {
            var topic = _mapper.Map<Topic>(topicDTO);
            await _context.Topics.AddAsync(topic);
            await _context.SaveChangesAsync();
            return topic;
        }

        public async Task<bool> DeleteTopicAsync(int id)
        {
            var topic = await _context.Topics.FirstOrDefaultAsync(c => c.TopicId == id);

            if (topic != null)
            {
                _context.Topics.Remove(topic);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Topic> UpdateTopicAsync(UpdateTopicDTO topicDTO, int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return null;
            }
            _mapper.Map(topicDTO, topic);
            _context.Topics.Update(topic);
            await _context.SaveChangesAsync();
            return topic;
        }
    }
}
