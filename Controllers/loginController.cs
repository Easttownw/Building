using BuildingADLRepositoryLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core;
using static BuildingADLRepositoryLib.Services.ServicesLogin.ServicesLogin;

namespace Building.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        public loginController(   IUnitOfWork  unit )
        {
                _unit= unit;
        }
        [HttpPost]
        [Route("LoginUser")]
        public IActionResult LoginUser([FromBody] User users)
        {
     
            try
            {
                var Login = _unit.login.LoginUser(users);
                if (Login == null) return NotFound();
                return Ok(Login);
            }
            catch (Exception ex)
            {

                return BadRequest("UserName or Password is incorrect");
            }


        }
    }
    }
