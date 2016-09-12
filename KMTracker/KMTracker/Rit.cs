using System.Collections.Generic;

namespace KMTracker
{
	public class Rit
	{
		public string Description
		{
			get;
		}

		List<Coordinate> Coordinates
		{
			get;
		}


		public Rit(string description, List<Coordinate> coordinates)
		{
			this.Description = description;
			this.Coordinates = coordinates;
		}
	}
}