using System;
using System.Collections.Generic;

namespace Domain.Models;
public partial class TableType 
{
    public short Code { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<DicTranslation> DicTranslations { get; set; } = new List<DicTranslation>();
}
