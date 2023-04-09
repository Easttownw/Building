using BuildingADLRepositoryLib.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public class IssueCustomerService : IIssueCustomerService
    {

    private readonly TechnicalSupportContext _context;
    public IssueCustomerService(TechnicalSupportContext context)
    {
        _context = context;

    }


    // <<<<<<<<<<<<<<<<<<<<<<<<<<< عرض جميع  مشاكل العميل>>>>>>>>>>>>>>>>>>>>>>>>>>>> 
    public IEnumerable getIssueCustomer() {

        
            try
            {
                return (from x in _context.IssueCustomers
                        select new
                        {
                      x.IssueID,
                      x.IsseDetail,
                      x.Serial,
                      x.IssueType,
                      x.IssueSubject,
                      x.IssueCustomerReopens,
                      x.Priority,
                      x.Answer,
                      x.AnswerDate,
                      x.Attachment,
                      x.UserId,
                      x.IS_close,
                      x.DateClose,
                      x.IS_ReOpen





                        }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return null;

    
     
     }
    //<<<<<<<<<<<<<<<<<<<<<<<<<<< عرض المشكه عن طريق id>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    public IEnumerable getIssueCustomerByID(int IssueID)
    {

        try
        {
            return (from x in _context.IssueCustomers
                    where x.IssueID == IssueID
                    select new
                    {
                        x.IssueID,
                        x.IsseDetail,
                        x.Serial,
                        x.IssueType,
                        x.IssueSubject,
                        x.IssueCustomerReopens,
                        x.Priority,
                        x.Answer,
                        x.AnswerDate,
                        x.Attachment,
                        x.UserId,
                        x.IS_close,
                        x.DateClose,
                        x.IS_ReOpen



                    });
        }
        catch (Exception)
        {

            throw;
        }

    }
    //<<<<<<<<<<<<<<<<<<<<<<<<<<<< اضافه مشكله جديد للعميل >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    public List<IssueCustomer> SaveIssueCustomer(IssueCustomersList _obIssueCustomersList)
    {

        try
        {
            IssueCustomer _ob = new IssueCustomer();
            _ob.IssueSubject = _obIssueCustomersList.IssueSubject; _ob.Date = _obIssueCustomersList.Date; _ob.Priority = _obIssueCustomersList.Priority;
            _ob.IssueType = _obIssueCustomersList.IssueType; _ob.IsseDetail = _obIssueCustomersList.IsseDetail; _ob.Answer = _obIssueCustomersList.Answer;
            _ob.AnswerDate = _obIssueCustomersList.AnswerDate; _ob.Attachment = _obIssueCustomersList.Attachment; _ob.UserId = _obIssueCustomersList.UserId;
            _ob.IS_close = _obIssueCustomersList.IS_close; _ob.DateClose = _obIssueCustomersList.DateClose; _ob.IS_ReOpen = _obIssueCustomersList.IS_ReOpen;
            _ob.Serial = _obIssueCustomersList.Serial ;   
           // if (_obIssueCustomersList.IssueID == _ob.IssueID) { for (int i = 0; i <= _ob.Serial; i++) { _ob.Serial++; } } else { return null; }

            _context.Add<IssueCustomer>(_ob);


            _context.SaveChanges();


            //var items = (List<IssueCustomer>)
            //   (from x in _context.IssueCustomers where x.IssueID == _ob.IssueID select x).Count();
        

          //  return items;
        }
        catch (Exception ex)
        {

        }
        return null;

    }
    //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<حل مشكله العميل>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    public List<IssueCustomer> UpdateIssueCustomer(IssueCustomersList _obIssueCustomersList)
    {
        try
        {
            IssueCustomer _ob = _context.IssueCustomers.Find(_obIssueCustomersList.IssueID);
            if (_ob is not null)

            {
                _ob.IssueSubject = _obIssueCustomersList.IssueSubject; _ob.Date = _obIssueCustomersList.Date; _ob.Priority = _obIssueCustomersList.Priority;
                _ob.IssueType = _obIssueCustomersList.IssueType; _ob.IsseDetail = _obIssueCustomersList.IsseDetail; _ob.Answer = _obIssueCustomersList.Answer;
                _ob.AnswerDate = _obIssueCustomersList.AnswerDate; _ob.Attachment = _obIssueCustomersList.Attachment; _ob.UserId = _obIssueCustomersList.UserId;
                _ob.IS_close = _obIssueCustomersList.IS_close; _ob.DateClose = _obIssueCustomersList.DateClose; _ob.IS_ReOpen = _obIssueCustomersList.IS_ReOpen;


                _context.Update<IssueCustomer>(_ob);

            }
            _context.SaveChanges();
            var items = (List<IssueCustomer>)
               (from x in _context.IssueCustomers where x.IssueID == _ob.IssueID select x).ToList();

            return items;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public class IssueCustomersList
    {
            public int IssueID { get; set; }

    public int Serial { get; set; }

    public DateTime Date { get; set; }

    /// <summary>
    /// 1-طوارىء
    /// 2- عاجل
    /// 3-عادى
    /// </summary>
    public byte Priority { get; set; }

    /// <summary>
    /// 1-  ويب ابليكشن
    /// 2- موبايل ابليكشن
    /// 3- موقع اليكترونى
    /// 4- ايميلات
    /// </summary>
    public byte IssueType { get; set; }

    public string? IssueSubject { get; set; }

    public string? IsseDetail { get; set; }

    public string? Answer { get; set; }

    public DateTime? AnswerDate { get; set; }

    public string? Attachment { get; set; }

    public int UserId { get; set; }

    public bool IS_close { get; set; }

    public DateTime? DateClose { get; set; }

    public bool IS_ReOpen { get; set; }
}












}

