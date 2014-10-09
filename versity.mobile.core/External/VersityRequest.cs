using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using versity.data.Models;
using RestSharp;
using Newtonsoft.Json;

namespace versity.mobile.core.External
{
    public class VersityRequest
    {
        public List<Item> GetItems (decimal budget) {
            client = new RestClient(baseUrl);
            request = new RestRequest(searchUrl, Method.GET);
            request.AddParameter("Budget", budget);

            var response = client.Execute(request);

            var items = JsonConvert.DeserializeObject<List<Item>>(response.Content);

            return items;
        }

        private RestClient client;
        private RestRequest request;
        private IRestResponse response;


        private const string baseUrl = "http://www.versitymenus.com";
        private const string searchUrl = "/Items/SearchBudget";
    }
}
