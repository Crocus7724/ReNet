using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace CounterExample.Droid
{
    [Activity(Label = "CounterExample", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var incrementButton = FindViewById<Button>(Resource.Id.increment_button);
            incrementButton.Touch += (sender, args) => App.Current.Store.Dispatch(new IncreaseAction());

            var decrementButton = FindViewById<Button>(Resource.Id.decrement_button);
            decrementButton.Touch += (sender, args) => App.Current.Store.Dispatch(new DecreaseAction());

            var textView = FindViewById<TextView>(Resource.Id.counter);
            App.Current.Store.Subscribe(state => textView.Text = state.Counter.ToString());
        }
    }
}