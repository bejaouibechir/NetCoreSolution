﻿using System;
using System.Collections.Generic;

namespace WebApiSec.Model;

public partial class UserViewModel
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
