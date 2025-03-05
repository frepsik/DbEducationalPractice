using System;
using System.Collections.Generic;

namespace EventManagement.Models.Database;

public partial class Direction
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Jury> Juries { get; set; } = new List<Jury>();

    public virtual ICollection<Moderator> Moderators { get; set; } = new List<Moderator>();
}
