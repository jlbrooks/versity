using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versity.data.Models;
using versity.data.DataAccess.EntityFramework;
using System.Data.Entity;

namespace versity.data.DataAccess
{
    public class LocationStore : ILocationStore
    {
        public LocationStore(VersityDataContext context)
        {
            _context = context;
        }

        public IQueryable<Location> Query
        {
            get { return _context.Locations; }
        }

        public Location GetByLocationID(int id)
        {
            return _context.Locations.SingleOrDefault(x => x.ID == id);
        }

        public void Update(Location Location)
        {
            _context.Entry(Location).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Add(Location Location)
        {
            _context.Locations.Add(Location);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var Location = GetByLocationID(id);
            if (Location != null)
            {
                _context.Locations.Remove(Location);
                _context.SaveChanges();
            }
        }

        private readonly VersityDataContext _context;
    }
}