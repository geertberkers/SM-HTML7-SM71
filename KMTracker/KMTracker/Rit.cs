using System.Collections.Generic;

namespace KMTracker
{
	public class Rit
	{
		public string Description
		{
			get;
		}

		public List<Coordinate> Coordinates
		{
			get;
		}

		public Rit(string description, List<Coordinate> coordinates)
		{
			Description = description;
			Coordinates = coordinates;
		}
	}
}