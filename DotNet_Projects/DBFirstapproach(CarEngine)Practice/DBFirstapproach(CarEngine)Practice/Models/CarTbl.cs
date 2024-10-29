using System;
using System.Collections.Generic;

namespace DBFirstapproach_CarEngine_Practice.Models;

public partial class CarTbl
{
    public int CarId { get; set; }

    public string CarName { get; set; } = null!;

    public int EngineId { get; set; }

    public virtual EngineTbl Engine { get; set; } = null!;
}
