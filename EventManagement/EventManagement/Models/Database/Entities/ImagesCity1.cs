using System;
using System.Collections.Generic;

namespace EventManagement.Models.Database;

public partial class ImagesCity1
{
    public Guid Id { get; set; }

    public string ImagePath { get; set; } = null!;

    public virtual ICollection<ImagesCity> ImagesCities { get; set; } = new List<ImagesCity>();
}
