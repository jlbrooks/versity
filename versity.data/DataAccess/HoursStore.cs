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
    public class HoursStore : IHoursStore
    {
        public HoursStore(VersityDataContext context)
        {
            _context = context;
        }

        public IQueryable<Hours> Query
        {
            get { return _context.Hours; }
        }

        public Hours GetByHoursID(int id)
        {
            return _context.Hours.SingleOrDefault(x => x.ID == id);
        }

        public void Update(Hours Hours)
        {
            _context.Entry(Hours).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Add(Hours Hours)
        {
            _context.Hours.Add(Hours);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var Hours = GetByHoursID(id);
            if (Hours != null)
            {
                _context.Hours.Remove(Hours);
                _context.SaveChanges();
            }
        }

        private readonly VersityDataContext _context;
    }
}