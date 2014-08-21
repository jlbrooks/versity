using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versity.data.Models;

namespace versity.data.DataAccess
{
    public interface IItemStore
    {
        Item GetByItemID(int id);
        void Update(Item Item);
        void Add(Item Item);
        void Remove(int id);
    }
}
