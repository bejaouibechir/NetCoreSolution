using System;
using System.Collections.Generic;

namespace WebApiDBF.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Addresse { get; set; }

    public bool? Genre { get; set; }

    public int Discriminator { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public decimal? Salary { get; set; }

    public int? DaysOff { get; set; }

    public int? ManagerId { get; set; }

    public virtual ICollection<User> InverseManager { get; set; } = new List<User>();

    public virtual User? Manager { get; set; }
}
