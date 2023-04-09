using BuildingADLRepositoryLib.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IssueCustomerService;

public interface IIssueCustomerService
{

    // <<<<<<<<<<<<<<<<<<<<<<<<<<< عرض جميع  مشاكل العميل>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
    public IEnumerable getIssueCustomer();
    //<<<<<<<<<<<<<<<<<<<<<<<<<<< عرض المشكه عن طريق id>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    public IEnumerable getIssueCustomerByID(int IssueID);
    //<<<<<<<<<<<<<<<<<<<<<<<<<<<< اضافه مشكله جديد للعميل >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    public List<IssueCustomer> SaveIssueCustomer(IssueCustomersList _obIssueCustomersList);
    //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<حل مشكله العميل>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    public List<IssueCustomer> UpdateIssueCustomer(IssueCustomersList _obIssueCustomersList);


}
