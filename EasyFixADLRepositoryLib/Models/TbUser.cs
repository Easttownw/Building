using System;
using System.Collections.Generic;

namespace BuildingADLRepositoryLib.Models;

public partial class TbUser
{
    public int UserID { get; set; }

    public int CustomerID { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Is_active { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
