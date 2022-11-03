using API.Repository.Data;
using API.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private AccountRepository _accountRepository;
        public AccountController(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpPost]
        public ActionResult Register(string FullName, string Email, DateTime BirthDate, string Password)
        {
            try
            {
                var result = _accountRepository.Register(FullName, Email, BirthDate, Password);
                if (result == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Register Tidak Berhasil"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Register Berhasil"
                    });

                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }


        /*public ActionResult ChangePassword(string Passnew, string Password)
        {

        }*/
        /* public ActionResult Login(LoginVM login)
        {
            try
            {
                var data = _accountRepository.Login(login.Email,login.Password);
                if(data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Tidak Ditemukan"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Ditemukan",
                        Data = data

                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }*/


    }
}
