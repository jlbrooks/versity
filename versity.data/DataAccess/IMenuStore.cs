using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using versity.data.Models;

namespace versity.data.DataAccess
{
    public interface IMenuStore
    {
        Menu GetByMenuID(int id);
        void Update(Menu menu);
        void Add(Menu menu);
        void Remove(int id);
    }
}
