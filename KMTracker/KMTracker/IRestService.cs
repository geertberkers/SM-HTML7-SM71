using System.Collections.Generic;
using System.Threading.Tasks;

namespace KMTracker
{
	public interface IRestService
	{

		Task<List<Car>> GetCarsAsync();
	}
}