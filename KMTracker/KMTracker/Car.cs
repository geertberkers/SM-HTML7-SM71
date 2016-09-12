using System.Collections.Generic;

namespace KMTracker
{
	public class Car
	{
		public string Name
		{
			get;
		}

		public string NumberPlate{
			get;
		}

		public double MileAge
		{
			get;
		}

		public List<Rit> Ritten
		{
			get;
		}

		public Car(string name, string numberPlate, double mileAge)
		{
			Ritten = new List<Rit>();

			Name = name;
			MileAge = mileAge;
			NumberPlate = numberPlate;
		}

		public override string ToString()
		{
			return string.Format("Car: {0}, \nNumberPlate: {1}, \nMileage: {2}, \nRitten: {3}", Name, NumberPlate, MileAge, Ritten.Count);
		}

	}
}