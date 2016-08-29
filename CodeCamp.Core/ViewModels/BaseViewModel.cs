using CodeCamp.Core.Services;
using MvvmCross.Core.ViewModels;

namespace CodeCamp.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        protected readonly ISvccService Service;

        public BaseViewModel(ISvccService service)
        {
            Service = service;
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        private string _busyMessage;
        public string BusyMessage
        {
            get { return _busyMessage; }
            set { SetProperty(ref _busyMessage, value); }
        }



    }
}
