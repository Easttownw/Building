using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core;
using static BuildingADLRepositoryLib.Services.ServicesCustomer.ServicesCustomer;

namespace Building.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public CustomerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("getALLCustomer")]
        public IActionResult getALLCustomer()
        {
            return Ok(unitOfWork.Customer.GetALL());
        }
        [HttpGet]
        [Route("getByID/{id:int}")]
        public IActionResult getByID (int id)
        {
            return Ok(unitOfWork.Customer.GetbyID(id));

        }
        [HttpPost]
        [Route("PostCustomer")]
        public IActionResult PostCustomer(CustomerList customerList)
        {
            try
            {
                var Post = unitOfWork.Customer.PostCustomer(customerList);
                if(Post == null)return NotFound();
                return Ok(Post);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPut]
        [Route("UpdateCustomer")]
        public IActionResult UpdateCustomer(CustomerList customerList)
        {
            try
            {
                var Post = unitOfWork.Customer.UpdateCustomer(customerList);
                if (Post == null) return NotFound();
                return Ok(Post);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("deleteCustomer/{id:int}")]
        public IActionResult deleteCustomer(int id)
        {
            return Ok(unitOfWork.Customer.DeleteCustomer(id));
        }
    }
}
