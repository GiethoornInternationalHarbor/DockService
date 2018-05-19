using System;
using System.Collections.Generic;
using System.Text;

namespace DockService.Core.Messaging
{
    public enum EventTypes
    {
        Unknown,
        ShipNearingHarbor,
        ShipUndock,
        DispatchTugbboat,
        ShipDocked,
        ShipUndocked
    }
}
