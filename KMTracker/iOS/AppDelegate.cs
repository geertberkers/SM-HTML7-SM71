using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace KMTracker.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			//Init Xamarin Forms
			Xamarin.Forms.Forms.Init();

			//Init Maps
			Xamarin.FormsMaps.Init();

			LoadApplication(new App());

			// Set Screen Width and Height
			App.ScreenWidth = UIScreen.MainScreen.Bounds.Width;
			App.ScreenHeight = UIScreen.MainScreen.Bounds.Height;

			return base.FinishedLaunching(app, options);
		}
	}
}

