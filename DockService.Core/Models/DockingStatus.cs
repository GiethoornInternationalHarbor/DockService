using System;
using System.Collections.Generic;
using System.Text;

namespace DockService.Core.Models
{
    public enum DockingStatus
    {

        ShipDockingRequested,
		ShipDocked,
		ShipUndocking,
        ShipUndocked,
        Unknown
    }
}
