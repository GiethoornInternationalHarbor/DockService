using System;
using System.Collections.Generic;
using System.Text;

namespace DockService.Core.Messaging
{
    public interface IEventHandler
    {
        void Start(IEventHandlerCallback callback);
        void Stop();
    }
}
