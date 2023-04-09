using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Core;
using static IssueCustomerService;

namespace Building.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueCustomerServiceController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        public IssueCustomerServiceController(IUnitOfWork unit)
        {
            _unit = unit;

        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<< عرض جميع  مشاكل العميل>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
        [HttpGet]
        [Route("getIssueCustomer")]
        public IActionResult getIssueCustomer() => Ok(_unit._IIssueCustomerService.getIssueCustomer());
        //<<<<<<<<<<<<<<<<<<<<<<<<<<< عرض المشكه عن طريق id>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        [HttpGet("getIssueCustomerByID/{IssueID:int}")]
        public IActionResult getIssueCustomerByID(int IssueID)
        {
            return Ok(_unit._IIssueCustomerService.getIssueCustomerByID(IssueID));
        }
        [HttpPost]
        [Route("SaveIssueCustomer")]
        public IActionResult SaveIssueCustomer(IssueCustomersList _obIssueCustomersList)
        {
            var _ob = _unit._IIssueCustomerService.SaveIssueCustomer(_obIssueCustomersList);

            return Ok(_ob);
        }
        [HttpPut]
        [Route("UpdateIssueCustomer")]
        public IActionResult UpdateIssueCustomer(IssueCustomersList _obIssueCustomersList)
        {
            var _ob = _unit._IIssueCustomerService.UpdateIssueCustomer(_obIssueCustomersList);

            return Ok(_ob);
        }





    }
}
