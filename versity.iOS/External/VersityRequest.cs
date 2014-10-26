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
			request = new RestRequest (budgetUrl, Method.GET);
			request.AddParameter ("Budget", budget.ToString ());

			IRestResponse<List<Item>> response = client.Execute<List<Item>> (request);

			return response.Data;
		}

		private RestClient client;
		private RestRequest request;

		private const string baseUrl = "http://www.versitymenus.com";
		private const string budgetUrl = "Items/SearchBudget";
	}
}

