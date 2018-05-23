using DockService.Core.Models;
using DockService.Core.Repositories;
using DockService.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DockService.Infrastructure.Repositories
{
    public class ShipRepository : IShipRepository
    {
        private DockDbContext _database;
        public ShipRepository(DockDbContext database)
        {
            _database = database;
            //turn tracking off for ships table AND change default tracking to off for entire context. somehow it only works with both
            _database.Ships.AsNoTracking();
            _database.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        #region --CRUD--
        public async Task<Ship> CreateShip(Ship value)
        {

            //make new ship and add to db NOTE: this is always tracked
            var newShip = (await _database.Ships.AddAsync(value)).Entity;
            await _database.SaveChangesAsync();

            //set newly made ship to untracked and save again, this will prevent duplicate keys in most cases
            _database.Entry(newShip).State = EntityState.Detached;
            await _database.SaveChangesAsync();
            return newShip;
        }

        public Task<Ship> GetShip(Guid shipId)
        {
            return _database.Ships.AsNoTracking().LastOrDefaultAsync(r => r.Id == shipId);
        }

        public async Task UpdateShip(Ship value)
        {
            _database.Entry(value).State = EntityState.Detached;
            _database.Ships.Update(value);
            await _database.SaveChangesAsync();
        }

        public async Task DeleteShip(Guid shipId)
        {
            //get the ship we want to delete
            Ship shipToDelete = await GetShip(shipId);

            //delete ship
            _database.Entry(shipToDelete).State = EntityState.Deleted;
            await _database.SaveChangesAsync();

            //untrack ship in memory
            _database.Entry(shipToDelete).State = EntityState.Detached;
            await _database.SaveChangesAsync();
        }
        #endregion
    }
}
