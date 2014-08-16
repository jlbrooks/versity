using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versity.data.Models;

namespace versity.data.DataAccess
{
    public interface IRestaurantStore
    {
        Restaurant GetByRestaurantID(int id);
        IList<Restaurant> All();
        void Update(Restaurant restaurant);
        void Add(Restaurant restaurant);
        void Remove(int id);
    }
}
