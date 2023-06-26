using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;

namespace LearningManagementSystemAPI.Services
{
    public interface IAccountService
    {
        public Task<List<AccountDTO>> GetAllAccountAsync();
        public Task<Account> CreateAccountAsync(CreateAccountDTO accountDTO);
        public Task<Account> UpdateAccountAsync(UpdateAccountDTO accountDTO, int id);
        public Task<bool> DeleteAccountAsync(int id);
        public Task<string> LoginAsync(LoginDTO loginDTO);
        public Task<bool> ResetPasswordAsync(string email);
        public Task<Account> ChangePasswordAsync(ChangePasswordDTO accountDTO, string email);
        public Task<Account> UserUpdateAccountAsync(UserUpdateAccountDTO accountDTO, int id, IFormFile avatar);
    }
}
