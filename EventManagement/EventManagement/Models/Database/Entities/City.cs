using System;
using System.Collections.Generic;

namespace EventManagement.Models.Database;

public partial class City
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<ImagesCity> ImagesCities { get; set; } = new List<ImagesCity>();
}
