using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;

namespace CodeCamp.iOS.Views
{
    public partial class HomeView : MvxViewController
    {
        public HomeView() : base("HomeView", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            var set = this.CreateBindingSet<HomeView, Core.ViewModels.HomeViewModel>();
            //set.Bind(Label).To(vm => vm.Hello);
            //set.Bind(TextField).To(vm => vm.Hello);
            set.Apply();

        }
    }
}