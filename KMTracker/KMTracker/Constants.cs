using System;
namespace KMTracker
{
	public static class Constants
	{
		//public static string IP_ADDRESS = "http://145.93.50.177:1337"; // School
		//public static string IP_ADDRESS = "http://192.168.1.104:1337"; // Thuis
		public static string IP_ADDRESS = "https://kmtracker.herokuapp.com"; // Heroku deployed
		public static string GetCarsUrl = IP_ADDRESS + "/car";
		public static string GetRitCoordinates = IP_ADDRESS +"/rit/";
	}
}

