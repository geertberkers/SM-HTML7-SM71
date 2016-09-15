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

				foreach (Car car in cars)
				{
					int carIndex = cars.IndexOf(car);

					foreach (Rit rit in car.Ritten)
					{
						int ritIndex = car.Ritten.IndexOf(rit);
						Rit newRit = car.Ritten.GetRange(ritIndex, 1)[0];

						if (rit.Id == newRit.Id)
						{
							Rit thisRit = await GetRitFromRitID(rit.Id);

							cars.GetRange(carIndex, 1)[0].Ritten.GetRange(ritIndex, 1)[0].Description = thisRit.Description;
							cars.GetRange(carIndex, 1)[0].Ritten.GetRange(ritIndex, 1)[0].Coordinates = thisRit.Coordinates;
						}
					}
				}
				return cars;
			}
			else {
				return null;
			}
		}

		public async Task<Rit> GetRitFromRitID(int id)
		{
			var uri = new Uri(string.Format(Constants.GetRitCoordinates + id, string.Empty));
			var response = await client.GetAsync(uri);

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				System.Diagnostics.Debug.WriteLine(content);
				return JsonConvert.DeserializeObject<Rit>(content);
			}
			else {
				return null;
			}
		}
	}
}

