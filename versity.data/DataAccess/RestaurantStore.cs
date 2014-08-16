using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versity.data.DataAccess.EntityFramework;
using versity.data.Models;

namespace versity.data.DataAccess
{
    public class RestaurantStore : IRestaurantStore
    {
        public RestaurantStore(VersityDbContext context)
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

        private readonly VersityDbContext _context;
    }
}
