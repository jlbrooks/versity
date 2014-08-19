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
    public class MenuStore : IMenuStore
    {
        public MenuStore(VersityDbContext context)
        {
            _context = context;
        }

        public IQueryable<Menu> Query
        {
            get { return _context.Menus; }
        }

        public Menu GetByMenuID(int id)
        {
            return _context.Menus.SingleOrDefault(x => x.ID == id);
        }

        public void Update(Menu Menu)
        {
            _context.Entry(Menu).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Add(Menu Menu)
        {
            _context.Menus.Add(Menu);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var Menu = GetByMenuID(id);
            if (Menu != null)
            {
                _context.Menus.Remove(Menu);
                _context.SaveChanges();
            }
        }

        private readonly VersityDbContext _context;
    }
}
