using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public interface IAccountService
    {
        //public Task<List<AccountDTO>> GetAllAccountAsync();
        public Task<Account> CreateAccountAsync(CreateAccountDTO accountDTO);
        //public Task<Account> UpdateAccountAsync(UpdateAccountDTO accountDTO, int id);
        //public Task<bool> DeleteAccountAsync(int id);
    }
}
