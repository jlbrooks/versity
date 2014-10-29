using System;
using System.Net;
using RestSharp;
using versity.data.Models;
using System.Collections.Generic;

namespace versity.ios
{
	public class VersityRequest
	{
		public VersityRequest ()
		{
			client = new RestClient (baseUrl);
		}

		public List<Item> GetItems (decimal budget) {
			request = new RestRequest (itemUrl, Method.GET);
			request.AddParameter ("Budget", budget.ToString ());

			IRestResponse<List<Item>> response = client.Execute<List<Item>> (request);

			return response.Data;
		}

		public List<Restaurant> GetRestaurantsBudget(decimal budget) {
			request = new RestRequest(restaurantUrl, Method.GET);
			request.AddParameter ("budget", budget.ToString ());
			IRestResponse<List<Restaurant>> response = client.Execute<List<Restaurant>> (request);

			return response.Data;
		}

		private RestClient client;
		private RestRequest request;

		private const string baseUrl = "http://www.versitymenus.com";
		private const string itemUrl = "api/searchBudget";
		private const string restaurantUrl = "api/GetRestaurantsWithBudget";
	}
}

