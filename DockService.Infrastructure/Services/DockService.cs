using DockService.Core.Messaging;
using DockService.Core.Models;
using DockService.Core.Repositories;
using DockService.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DockService.Infrastructure.Services
{
	public class DockService : IDockService
	{
		private readonly IShipRepository _shipRepository;
		private readonly IEventPublisher _eventPublisher;

		public DockService(IShipRepository shipRepository, IEventPublisher eventPublisher)
		{
			_shipRepository = shipRepository;
			_eventPublisher = eventPublisher;
		}

		#region -- DB operations --
		public Task<Ship> CreateShipAsync(Ship ship)
		{
			return _shipRepository.CreateShip(ship);
		}

		public Task DeleteShipAsync(Guid shipId)
		{
			return _shipRepository.DeleteShip(shipId);
		}

		public Task<Ship> GetShipAsync(Guid shipId)
		{
			return _shipRepository.GetShip(shipId);
		}
		#endregion

		#region -- Events --
		public async Task SendShipDockedAsync(Ship ship)
		{
			#region -- convert to desired output--
			DockEventModel dem = new DockEventModel
			{
				CustomerId = ship.CustomerId,
				ShipId = ship.Id,
				ShipName = ship.Name,
				Containers = ship.Containers
			};
			#endregion

			Console.WriteLine("Docking ship: " + ship.Id);
			await _eventPublisher.HandleEventAsync(EventTypes.ShipDocked, dem);
		}

		public async Task SendShipUndockedAsync(Ship ship)
		{
			#region -- convert to desired output--
			DockEventModel dem = new DockEventModel
			{
				CustomerId = ship.CustomerId,
				ShipId = ship.Id,
				ShipName = ship.Name
			};
			#endregion

			Console.WriteLine("Undocking ship: " + ship.Id);
			await DeleteShipAsync(ship.Id);
			await _eventPublisher.HandleEventAsync(EventTypes.ShipUndocked, dem);
		}

		public async Task SendTugboatDispatchedAsync(Ship ship)
		{
			Console.WriteLine("Dispatching tugboats to ship: " + ship.Id);

			#region -- convert to desired output--
			DockEventModel dem = new DockEventModel
			{
				CustomerId = ship.CustomerId,
				ShipId = ship.Id,
				ShipName = ship.Name
			};
			#endregion

			await _eventPublisher.HandleEventAsync(EventTypes.DispatchTugbboat, dem);
		}
		#endregion
	}
}
