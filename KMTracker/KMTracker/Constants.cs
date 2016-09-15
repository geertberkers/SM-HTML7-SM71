using System;
namespace KMTracker
{
	public static class Constants
	{
		public static string IP_ADDRESS = "145.93.50.177";
		public static string GetCarsUrl = "http://" + IP_ADDRESS + ":1337/car";
		public static string GetRitCoordinates = "http://"+ IP_ADDRESS +":1337/rit/";
	}
}

