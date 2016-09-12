using System;

namespace KMTracker
{
	public class Coordinate
	{
		public double Longitude;
		public double Latitude;

		public Coordinate(double latitude, double longitude)
		{
			this.Longitude = longitude;
			this.Latitude = latitude;
		}
	}
}