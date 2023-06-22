using AutoMapper;
using LearningManagementSystemAPI.Context;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly LmsContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        
        public AccountService(LmsContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<Account> CreateAccountAsync(CreateAccountDTO accountDTO)
        {
            var account = _mapper.Map<Account>(accountDTO);

            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();

            return account;
        }

        //public async Task<bool> DeleteAccountAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<List<AccountDTO>> GetAllAccountAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<Account> UpdateAccountAsync(UpdateAccountDTO accountDTO, int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
