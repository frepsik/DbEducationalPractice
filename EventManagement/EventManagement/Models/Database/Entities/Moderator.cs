using System;
using System.Collections.Generic;

namespace EventManagement.Models.Database;

public partial class Moderator
{
    public Guid Id { get; set; }

    public Guid DirectionId { get; set; }

    public Guid? ModeratorEventId { get; set; }

    public Guid UserId { get; set; }

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    public virtual Direction Direction { get; set; } = null!;

    public virtual ModeratorsEvent? ModeratorEvent { get; set; }

    public virtual User User { get; set; } = null!;
}
