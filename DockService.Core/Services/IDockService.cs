using DockService.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DockService.Core.Services
{
    public interface IDockService
    {
        #region --persistance---
        /// <summary>
        /// Creates the ship asynchronous.
        /// </summary>
        /// <param name="ship">The Ship object.</param>
        /// <returns></returns>
        Task<Ship> CreateShipAsync(Ship ship);

        /// <summary>
        /// Get a ship
        /// </summary>
        /// <param name="shipId">The guid of the required ship.</param>
        /// <returns></returns>
        Task<Ship> GetShipAsync(Guid shipId);

        /// <summary>
        /// Delete a ship
        /// </summary>
        /// <param name="shipId">The guid of the ship.</param>
        /// <returns></returns>
        Task DeleteShipAsync(Guid shipId);
        #endregion

        #region --outgoing events---
        Task SendShipDockedAsync(Ship ship);//send event that ship is docked
        Task SendShipUndockedAsync(Ship ship);//send event that ship is undocked
        Task SendTugboatDispatchedAsyn(Ship ship);//send event that tugboats are dispatched
        #endregion
    }
}
