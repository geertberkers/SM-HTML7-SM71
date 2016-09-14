using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KMTracker
{
	public class RestService : IRestService
	{
		HttpClient client;

		public RestService()
		{
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
		}

		public async Task<List<Car>> GetCarsAsync()
		{
			var cars = new List<Car>();
			var uri = new Uri(string.Format(Constants.GetCarsUrl, string.Empty));

			var response = await client.GetAsync(uri);

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				cars = JsonConvert.DeserializeObject<List<Car>>(content);
				return cars;
			}
			else {
				return null;
			}
		}
	}
}

