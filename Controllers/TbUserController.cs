using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core;
using static BuildingADLRepositoryLib.Services.ServicesCustomer.ServicesCustomer;
using static BuildingADLRepositoryLib.Services.ServicesTbUser.ServicesTbUser;

namespace Building.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbUserController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public TbUserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("getALLTbUser")]
        public IActionResult getALLTbUser()
        {
            return Ok(unitOfWork.TbUser.GetAll());
        }
        [HttpGet]
        [Route("getByID/{id:int}")]
        public IActionResult getByID(int id)
        {
            return Ok(unitOfWork.TbUser.GetALLbyId(id));

        }
        [HttpPost]
        [Route("PostTbUser")]
        public IActionResult PostTbUser(TbUserLis tbUserLis)
        {
            try
            {
                var Post = unitOfWork.TbUser.PostTbUser(tbUserLis);
                if (Post == null) return NotFound();
                return Ok(Post);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPut]
        [Route("UpdateTbUser")]
        public IActionResult UpdateTbUser(TbUserLis tbUserLis)
        {
            try
            {
                var Post = unitOfWork.TbUser.updateTbUser(tbUserLis);
                if (Post == null) return NotFound();
                return Ok(Post);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("deleteTbUser/{id:int}")]
        public IActionResult deleteTbUser(int id)
        {
            return Ok(unitOfWork.TbUser.DeleeTbUser(id));
        }
    }
}
