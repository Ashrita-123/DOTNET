using System;
using System.Collections.Generic;

namespace DBFirstapproach_CarEngine_Practice.Models;

public partial class EngineTbl
{
    public int EngineId { get; set; }

    public string EngineType { get; set; } = null!;

    public virtual ICollection<CarTbl> CarTbls { get; set; } = new List<CarTbl>();
}
