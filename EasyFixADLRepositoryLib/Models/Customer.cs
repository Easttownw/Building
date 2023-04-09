using System;
using System.Collections.Generic;

namespace BuildingADLRepositoryLib.Models;

public partial class Customer
{
    public int CustomerID { get; set; }

    public string CustomerName { get; set; } = null!;

    public string? Tel { get; set; }

    public string? Address { get; set; }

    public string Responsabilty { get; set; } = null!;

    public string? Notes { get; set; }
    public string? Email { get; set; }

    public virtual ICollection<TbUser> TbUsers { get; } = new List<TbUser>();
}

