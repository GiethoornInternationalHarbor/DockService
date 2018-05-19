using DockService.Core.Messaging;
using DockService.Core.Models;
using DockService.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DockService.Infrastructure.Services
{
    public class DockService : IDockService
    {
        private const int CHECK_DURATION = 30000;
       
        private readonly IEventPublisher _eventPublisher;

        public DockService(IEventPublisher eventPublisher)
        {        
            _eventPublisher = eventPublisher;
           }

        #region ---for extendability---
        public Task<Ship> CreateShipAsync(Ship ship)
        {
            throw new NotImplementedException();
        }

        Task<Ship> IDockService.GetShipAsync(string serial)
        {
            throw new NotImplementedException();
        }

        public Task<Ship> SaveShipAsync(Ship ship)
        {
            throw new NotImplementedException();
        }
        #endregion
        public Task SendShipDockedAsync(Ship ship)
        {
            return Task.Run(async () =>
            {
                ship.DockingStatus = DockingStatus.ShipDocked;
                await _eventPublisher.HandleEventAsync(EventTypes.ShipDocked, ship);
            });
        }

        public Task SendShipUndockedAsync(Ship ship)
        {
            return Task.Run(async () =>
            {
                ship.DockingStatus = DockingStatus.ShipUndocked;
                await _eventPublisher.HandleEventAsync(EventTypes.ShipUndocked, ship);
            });
        }

        public Task SendTugboatDispatchedAsyn(Ship ship)
        {
            return Task.Run(async () =>
            {
                ship.DockingStatus = DockingStatus.Unknown;
                ship.ShipType = ShipType.Tugboat;
                //leave serial as is but overwrite the shiptype to send out event that tugboat is dispatched to ship with serial X
                await _eventPublisher.HandleEventAsync(EventTypes.DispatchTugbboat, ship);
            });
        }
    }
}
