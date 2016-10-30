using System;
using ReNet.iOS.Routing;
using ReNet.Routing;
using UIKit;

namespace RoutingExample.iOS
{
    [Routing("SubView", "SubView", StoryboardName = "Sub")]
    public partial class SubViewController : UIViewController
    {
        public SubViewController() : base("SubViewController", null)
        {
        }

        protected SubViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            App.Current.Store.Subscribe(x => CountLabel.Text = x.PageNumber.ToString());

            NextButton.TouchUpInside += (sender, args) => App.Current.Store.Dispatch(new NextPageAction("SubView"));
            PreviousButton.TouchUpInside += (sender, args) => App.Current.Store.Dispatch(new PreviousPageAction(3));
            AnotherStoryboardButton.TouchUpInside +=
                (sender, args) => App.Current.Store.Dispatch(new NextPageAction("MainView"));
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}