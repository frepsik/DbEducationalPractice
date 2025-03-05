using System;
using System.Collections.Generic;

namespace EventManagement.Models.Database;

public partial class Gender
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
