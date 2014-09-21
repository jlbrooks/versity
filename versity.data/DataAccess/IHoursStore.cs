using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versity.data.Models;

namespace versity.data.DataAccess
{
    public interface IHoursStore
    {
        Hours GetByHoursID(int id);
        void Update(Hours Hours);
        void Add(Hours Hours);
        void Remove(int id);
    }
}
