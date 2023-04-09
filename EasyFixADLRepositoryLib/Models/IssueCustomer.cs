using System;
using System.Collections.Generic;

namespace BuildingADLRepositoryLib.Models;

public partial class IssueCustomer
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

    public virtual ICollection<IssueCustomerReopen> IssueCustomerReopens { get; } = new List<IssueCustomerReopen>();
}
