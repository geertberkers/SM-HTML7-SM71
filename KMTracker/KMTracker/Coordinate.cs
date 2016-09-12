namespace KMTracker
{
	public class Coordinate
	{
		public double Longitude;
		public double Latitude;

		public Coordinate(double longitude, double latitude)
		{
			this.Longitude = longitude;
			this.Latitude = latitude;
		}

		public double GetLongitude()
		{
			return Longitude;
		}

		public double GetLatitude()
		{
			return Latitude;
		}
	}
}