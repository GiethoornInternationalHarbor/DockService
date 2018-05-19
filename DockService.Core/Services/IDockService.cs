using DockService.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DockService.Core.Services
{
    public interface IDockService
    {
        #region --required for persistance---
        Task<Ship> CreateShipAsync(Ship ship);
        Task<Ship> GetShipAsync(string serial);
        Task<Ship> SaveShipAsync(Ship ship);
        #endregion

        #region --send events---
        Task SendShipDockedAsync(Ship ship);//send event that ship is docked
        Task SendShipUndockedAsync(Ship ship);//send event that ship is undocked
        Task SendTugboatDispatchedAsyn(Ship ship);//send event that tugboats are dispatched
        #endregion
    }
}
