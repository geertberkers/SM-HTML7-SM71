namespace KMTracker
{
	public class Coordinate
	{
		public Longitude Longitude;
		public Latitude Latitude;


		public Coordinate(Latitude latitude, Longitude longitude)
		{
			Longitude = longitude;
			Latitude = latitude;
		}

		public Coordinate(double v1, double v2)
		{
			Longitude = new Longitude { longitude = v1 };
			Latitude = new Latitude { latitude = v2 };
		}
	}
}