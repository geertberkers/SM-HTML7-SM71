using System.Collections.Generic;

namespace KMTracker
{
	public class Rit
	{

		public int Id
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public List<Coordinate> Coordinates
		{
			get;
			set;
		}

		public Rit(string description, List<Coordinate> coordinates)
		{
			Description = description;
			Coordinates = coordinates;
		}
	}
}