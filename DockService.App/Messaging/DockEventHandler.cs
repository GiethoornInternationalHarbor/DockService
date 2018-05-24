using DockService.Core.Messaging;
using DockService.Core.Models;
using DockService.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utf8Json;

namespace DockService.App.Messaging
{
	public class DockEventHandler : IEventHandlerCallback
	{
		private readonly IDockService _dockService;
		public DockEventHandler(IDockService dockService)
		{
			_dockService = dockService;
		}

		#region --- main stuff---
		public async Task<bool> HandleEventAsync(EventTypes eventType, string message)
		{
			switch (eventType)
			{
				case EventTypes.ShipNearingHarbor:
					{
						return await HandleShipNearingHarbor(message);
					}
				case EventTypes.ShipUndock:
					{
						return await HandleShipUndock(message);
					}
				case EventTypes.Unknown:
					{
						return true;
					}
			}

			return true;
		}
		#endregion

		#region --- Incoming Dock and Undock events ---
		private async Task<bool> HandleShipNearingHarbor(string message)
		{

			var receivedShip = JsonSerializer.Deserialize<DockEventModel>(message);
			Ship createdShip = await _dockService.CreateShipAsync(new Ship() { Id = receivedShip.ShipId, Name = receivedShip.ShipName, Containers = receivedShip.Containers.ToList(), CustomerId = receivedShip.CustomerId });
			//Send tugboats to assist with undocking
			await _dockService.SendTugboatDispatchedAsync(createdShip);
			//Execute docking method
			await _dockService.SendShipDockedAsync(createdShip);

			return true;
		}

		private async Task<bool> HandleShipUndock(string message)
		{

			var receivedShip = JsonSerializer.Deserialize<DockEventModel>(message);
			//Send tugboats to assist with undocking
			await _dockService.SendTugboatDispatchedAsync(new Ship() { Id = receivedShip.ShipId, Name = receivedShip.ShipName, Containers = receivedShip.Containers.ToList(), CustomerId = receivedShip.CustomerId });
			//Execute undocking method
			await _dockService.SendShipUndockedAsync(new Ship() { Id = receivedShip.ShipId, Name = receivedShip.ShipName, Containers = receivedShip.Containers.ToList(), CustomerId = receivedShip.CustomerId });
			return true;
		}
		#endregion

	}
}