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
	[Register ("OtherViewController")]
	partial class OtherViewController
	{
		[Outlet]
		UIKit.UILabel CountLabel { get; set; }

		[Outlet]
		UIKit.UIButton MainStoryboardButton { get; set; }

		[Outlet]
		UIKit.UIButton NextButton { get; set; }

		[Outlet]
		UIKit.UIButton PreviousButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CountLabel != null) {
				CountLabel.Dispose ();
				CountLabel = null;
			}

			if (MainStoryboardButton != null) {
				MainStoryboardButton.Dispose ();
				MainStoryboardButton = null;
			}

			if (NextButton != null) {
				NextButton.Dispose ();
				NextButton = null;
			}

			if (PreviousButton != null) {
				PreviousButton.Dispose ();
				PreviousButton = null;
			}
		}
	}
}
