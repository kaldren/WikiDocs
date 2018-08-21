using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wiki.App_Code
{
    public abstract class BaseEntry
    {
        public EntityStatus Status { get; set; }
    }
}