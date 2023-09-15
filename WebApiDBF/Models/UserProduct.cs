using System;
using System.Collections.Generic;

namespace WebApiDBF.Models;

public partial class UserProduct
{
    public int? EmployeeId { get; set; }

    public int? ProductId { get; set; }

    public DateTime? Date { get; set; }

    public virtual User? Employee { get; set; }

    public virtual Product? Product { get; set; }
}
