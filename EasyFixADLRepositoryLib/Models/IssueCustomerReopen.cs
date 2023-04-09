using System;
using System.Collections.Generic;

namespace BuildingADLRepositoryLib.Models;

public partial class IssueCustomerReopen
{
    public int ReIssueID { get; set; }

    public int IssueID { get; set; }

    public string Details { get; set; } = null!;

    public DateTime Date { get; set; }

    public int UserID { get; set; }

    public string? Answer { get; set; }

    public DateTime? AnswerDate { get; set; }

    public virtual IssueCustomer Issue { get; set; } = null!;
}
