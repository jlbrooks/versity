using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace versity.External
{
    public interface IGeocoder
    {
        Tuple<double, double> GeocodeAddress(string address, string city, string state, string zip);
    }
}
