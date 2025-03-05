using System;
using System.Collections.Generic;

namespace EventManagement.Models.Database;

public partial class Country
{
    public Guid Id { get; set; }

    public string RussianName { get; set; } = null!;

    public string EnglishName { get; set; } = null!;

    public string FirstCode { get; set; } = null!;

    public int SecondCode { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
