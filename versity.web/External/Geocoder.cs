using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JsonUtils;

namespace versity.External
{
    public class Geocoder : IGeocoder
    {

        public Tuple<double, double> GeocodeAddress(string address, string city, string state, string zip)
        {
            double lat, lng;

            var address_string = address + city + state + zip;

            var request = baseurl + "?address=" + address_string + "&key=" + key;

            dynamic response = new Uri(request).GetDynamicJsonObject();

            if (response.status == "OK")
            {
                lat = response.results[0].geometry.location.lat;
                lng = response.results[0].geometry.location.lng;
            }
            else
            {
                lat = 0.0;
                lng = 0.0;
            }

            return new Tuple<double, double>(lat, lng);
        }

        private const string baseurl = "https://maps.googleapis.com/maps/api/geocode/json";
        private const string key = "AIzaSyCWqzWVAK9vP6j6hO2sRL0YogDqvEXiY6g";
    }
}