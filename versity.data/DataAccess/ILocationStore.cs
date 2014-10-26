using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versity.data.Models;

namespace versity.data.DataAccess
{
    public interface ILocationStore
    {
        Location GetByLocationID(int id);
        void Update(Location loc);
        void Add(Location loc);
        void Remove(int id);
    }
}
