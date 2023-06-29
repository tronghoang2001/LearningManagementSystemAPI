using AutoMapper;
using LearningManagementSystemAPI.Context;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystemAPI.Services
{
    public class PrivateFilesService : IPrivateFilesService
    {
        private readonly LmsContext _context;
        private readonly IMapper _mapper;
        public PrivateFilesService(LmsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PrivateFiles> CreatePrivateFilesAsync(CreatePrivateFilesDTO privateFilesDTO, IFormFile file)
        {
            var privateFile = _mapper.Map<PrivateFiles>(privateFilesDTO);
            if (file != null && file.Length > 0)
            {
                var fileName = file.FileName;
                var filePath = Path.Combine("Uploads\\PrivateFiles", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                privateFile.CreateDate = DateTime.Now;
                privateFile.UpdateDate = DateTime.Now;
                privateFile.FileName = fileName;
                privateFile.Size = file.Length / (1024.0 * 1024.0);
            }
            await _context.PrivateFiles.AddAsync(privateFile);
            await _context.SaveChangesAsync();

            return privateFile;
        }

        public async Task<bool> DeletePrivateFilesAsync(int id)
        {
            var privateFile = await _context.PrivateFiles.FirstOrDefaultAsync(p => p.PrivateFilesId == id);

            if (privateFile != null)
            {
                var filePath = Path.Combine("Uploads\\PrivateFiles", privateFile.FileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                _context.PrivateFiles.Remove(privateFile);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<PrivateFilesDTO>> GetAllPrivateFilesAsync()
        {
            var privateFiles = await _context.PrivateFiles.ToListAsync();
            return _mapper.Map<List<PrivateFilesDTO>>(privateFiles);
        }

        public async Task<PrivateFiles> UpdatePrivateFilesAsync(CreatePrivateFilesDTO privateFilesDTO, int id, IFormFile file)
        {
            var privateFile = await _context.PrivateFiles.FindAsync(id);
            if (privateFile == null)
            {
                return null;
            }
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine("Uploads\\PrivateFiles", privateFile.FileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                var fileName = file.FileName;
                filePath = Path.Combine("Uploads\\PrivateFiles", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                privateFile.UpdateDate = DateTime.Now;
                privateFile.FileName = fileName;
                privateFile.Size = file.Length / (1024.0 * 1024.0);
            }
            _mapper.Map(privateFilesDTO, privateFile);
            _context.PrivateFiles.Update(privateFile);
            await _context.SaveChangesAsync();
            return privateFile;
        }
    }
}
