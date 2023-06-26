using LearningManagementSystemAPI.DTOs;
using LearningManagementSystemAPI.Models;
using LearningManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LearningManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("list-account")]
        public async Task<IActionResult> GetAllAccount()
        {
            try
            {
                return Ok(await _accountService.GetAllAccountAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create-account")]
        public async Task<IActionResult> CreateAccount(CreateAccountDTO accountDTO)
        {
            try
            {
                var account = await _accountService.CreateAccountAsync(accountDTO);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("update-account/{id}")]
        public async Task<ActionResult<Account>> UpdateAccount(UpdateAccountDTO accountDTO, int id)
        {
            try
            {
                var account = await _accountService.UpdateAccountAsync(accountDTO, id);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete-account/{id}")]
        public async Task<ActionResult> DeleteAccount(int id)
        {
            var result = await _accountService.DeleteAccountAsync(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok("Delete Success!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDto)
        {
            var result = await _accountService.LoginAsync(loginDto);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(string email)
        {
            var isSuccess = await _accountService.ResetPasswordAsync(email);
            if (!isSuccess)
            {
                return StatusCode(500, "Gửi mật khẩu mới đến Email không thành công!");
            }

            return Ok();
        }

        [Authorize]
        [HttpPut("change-password/{email}")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO accountDTO, string email)
        {
            try
            {
                var account = await _accountService.ChangePasswordAsync(accountDTO, email);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("user-update-account/{id}")]
        public async Task<IActionResult> UserUpdateAccount([FromForm] UserUpdateAccountDTO accountDTO, int id, IFormFile avatar)
        {
            try
            {
                var account = await _accountService.UserUpdateAccountAsync(accountDTO, id, avatar);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
