using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace CodeCamp.Droid.Views
{
    [Activity(Label = "Silicon Valley Code Camp")]
    public class HomeView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HomeView);
        }
    }
}
