// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace CounterExample.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UILabel Count { get; set; }

		[Outlet]
		UIKit.UIButton DecrementButton { get; set; }

		[Outlet]
		UIKit.UIButton IncrementButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Count != null) {
				Count.Dispose ();
				Count = null;
			}

			if (IncrementButton != null) {
				IncrementButton.Dispose ();
				IncrementButton = null;
			}

			if (DecrementButton != null) {
				DecrementButton.Dispose ();
				DecrementButton = null;
			}
		}
	}
}
