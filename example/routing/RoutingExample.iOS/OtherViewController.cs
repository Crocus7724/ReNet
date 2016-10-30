using System;
using ReNet.iOS.Routing;
using UIKit;

namespace RoutingExample.iOS
{
    [Route("OtherView",UseXib = true)]
    public partial class OtherViewController : UIViewController
    {
        public OtherViewController() : base("OtherViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            App.Current.Store.Subscribe(x => CountLabel.Text = x.PageNumber.ToString());

            NextButton.TouchUpInside += (sender, args) => App.Current.Store.Dispatch(new NextPageAction("OtherView"));
            PreviousButton.TouchUpInside += (sender, args) => App.Current.Store.Dispatch(new PreviousPageAction());
            MainStoryboardButton.TouchUpInside +=
                (sender, args) => App.Current.Store.Dispatch(new NextPageAction("MainView"));
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

