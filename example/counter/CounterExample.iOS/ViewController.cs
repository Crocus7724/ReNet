using System;
using UIKit;

namespace CounterExample.iOS
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            IncrementButton.TouchUpInside += (sender, args) => App.Current.Store.Dispatch(new IncreaseAction());
            DecrementButton.TouchUpInside += (sender, args) => App.Current.Store.Dispatch(new DecreaseAction());

            App.Current.Store.Subscribe(state => Count.Text = state.Counter.ToString());
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}