using AutoMapper;
using LearningManagementSystemAPI.Context;
using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Helpers;
using LearningManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MailKit.Net.Smtp;
using Org.BouncyCastle.Crypto.Generators;

namespace LearningManagementSystemAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly LmsContext _context;
        private readonly GenerateToken _generateToken;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AccountService(LmsContext context, IConfiguration configuration, IMapper mapper, GenerateToken generateToken)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
            _generateToken = generateToken; 
        }
        public async Task<Account> CreateAccountAsync(CreateAccountDTO accountDTO)
        {
            var account = _mapper.Map<Account>(accountDTO);

            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();

            return account;
        }

        public async Task<bool> DeleteAccountAsync(int id)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(c => c.AccountId == id);

            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<AccountDTO>> GetAllAccountAsync()
        {
            var accounts = await _context.Accounts.ToListAsync();
            return _mapper.Map<List<AccountDTO>>(accounts);
        }

        public async Task<Account> UpdateAccountAsync(UpdateAccountDTO accountDTO, int id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return null;
            }

            var role = await _context.Roles.FindAsync(accountDTO.RoleId);
            
            account.RoleName = role.Name;

            _mapper.Map(accountDTO, account);
            _context.Accounts.Update(account);
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();

            return account;
        }
        public Task<string> LoginAsync(LoginDTO loginDTO)
        {
            var account = Authenticate(loginDTO);
            if (account != null)
            {
                var token = _generateToken.CalculateToken(account);
                return Task.FromResult(token);
            }
            return Task.FromResult(string.Empty);
        }
        private Account Authenticate(LoginDTO loginDTO)
        {
            var currentUser = _context.Accounts.FirstOrDefault(a => a.Email.ToLower() ==
                loginDTO.Email.ToLower());
            if (currentUser != null && currentUser.Password == MD5Encryption.CalculateMD5(loginDTO.Password))
            {
                return currentUser;
            }
            return null;
        }

        public async Task<bool> ResetPasswordAsync(string email)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email);
            if (account == null)
            {
                return false;
            }

            var newPassword = Guid.NewGuid().ToString();
            account.Password = MD5Encryption.CalculateMD5(newPassword);
            await _context.SaveChangesAsync();

            return await SendPasswordResetEmailAsync(account.Email, newPassword);
        }
        private async Task<bool> SendPasswordResetEmailAsync(string email, string newPassword)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("LMS System", "12a9nth@gmail.com"));
                message.To.Add(new MailboxAddress(email, email));

                message.Subject = "Password Reset";

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = $"<p>Mật khẩu mới của bạn là: {newPassword}</p>";

                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("sandbox.smtp.mailtrap.io", 465, false);
                    await client.AuthenticateAsync("36b82a08f96a82", "b102352bb625e9");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Account> ChangePasswordAsync(ChangePasswordDTO accountDTO, string email)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email);

            if (account == null)
            {
                return null;
            }

            if (MD5Encryption.CalculateMD5(accountDTO.CurrentPassword) != account.Password)
            {
                throw new Exception("Mật khẩu cũ không hợp lệ!");
            }

            if (accountDTO.NewPassword != accountDTO.ConfirmPassword)
            {
                throw new Exception("Xác nhận mật khẩu không trùng khớp!");
            }

            account.Password = MD5Encryption.CalculateMD5(accountDTO.NewPassword);
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();

            return account;
        }

        public async Task<Account> UserUpdateAccountAsync(UserUpdateAccountDTO accountDTO, int id, IFormFile avatar)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return null;
            }
            if (avatar != null && avatar.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(avatar.FileName);
                var filePath = Path.Combine("Uploads\\Avatar", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await avatar.CopyToAsync(stream);
                }
                account.Avatar = fileName;
            }
            _mapper.Map(accountDTO, account);
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return account;
        }
    }
}
