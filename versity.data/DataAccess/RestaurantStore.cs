using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versity.data.DataAccess.EntityFramework;
using versity.data.Models;
using System.Data.Entity;

namespace versity.data.DataAccess
{
    public class RestaurantStore : IRestaurantStore
    {
        public RestaurantStore(VersityDataContext context)
        {
            _context = context;
        }

        public IQueryable<Restaurant> Query
        {
            get { return _context.Restaurants; }
        }

        public IList<Restaurant> All()
        {
            return Query.ToList();
        }

        public Restaurant GetByRestaurantID(int id)
        {
            return _context.Restaurants.SingleOrDefault(x => x.ID == id);
        }

        public void Update(Restaurant restaurant)
        {
            _context.Entry(restaurant).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var restaurant = GetByRestaurantID(id);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
                _context.SaveChanges();
            }
        }

        public IList<Restaurant> HasItemUnderBudget(decimal budget)
        {
            return All().Where(r => hasMenuUnderBudget(r, budget)).ToList();
        }

        private bool hasMenuUnderBudget(Restaurant r, decimal budget)
        {
            return r.Menus.Any(m => hasItemUnderPrice(m, budget));
        }

        private bool hasItemUnderPrice(Menu m, decimal budget)
        {
            return m.Items.Any(i => i.Cost <= budget);
        }

        private readonly VersityDataContext _context;
    }
}
