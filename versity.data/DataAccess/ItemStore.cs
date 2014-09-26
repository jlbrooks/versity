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
    public class ItemStore : IItemStore
    {
        public ItemStore(VersityDbContext context)
        {
            _context = context;
        }

        public IQueryable<Item> Query
        {
            get { return _context.Items; }
        }

        public Item GetByItemID(int id)
        {
            return _context.Items.SingleOrDefault(x => x.ID == id);
        }

        public void Update(Item Item)
        {
            _context.Entry(Item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Add(Item Item)
        {
            _context.Items.Add(Item);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var Item = GetByItemID(id);
            if (Item != null)
            {
                _context.Items.Remove(Item);
                _context.SaveChanges();
            }
        }

        public List<Item> GetUnderPrice(decimal price)
        {
            return _context.Items.Where(x => x.Cost <= price).ToList();
        }

        private readonly VersityDbContext _context;
    }
}
