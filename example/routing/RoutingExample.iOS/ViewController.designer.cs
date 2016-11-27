// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace RoutingExample.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton AnotherStoryboardButton { get; set; }

		[Outlet]
		UIKit.UILabel CountLabel { get; set; }

		[Outlet]
		UIKit.UIButton NextButton { get; set; }

		[Outlet]
		UIKit.UIButton OtherXibButton { get; set; }

		[Outlet]
		UIKit.UIButton PreviousButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AnotherStoryboardButton != null) {
				AnotherStoryboardButton.Dispose ();
				AnotherStoryboardButton = null;
			}

			if (CountLabel != null) {
				CountLabel.Dispose ();
				CountLabel = null;
			}

			if (NextButton != null) {
				NextButton.Dispose ();
				NextButton = null;
			}

			if (PreviousButton != null) {
				PreviousButton.Dispose ();
				PreviousButton = null;
			}

			if (OtherXibButton != null) {
				OtherXibButton.Dispose ();
				OtherXibButton = null;
			}
		}
	}
}
