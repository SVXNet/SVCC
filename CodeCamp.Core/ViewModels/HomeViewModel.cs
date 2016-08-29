using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CodeCamp.Core.Models;
using CodeCamp.Core.Services;

namespace CodeCamp.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel(ISvccService service) : base(service)
        {
        }

        public ObservableCollection<Session> Sessions { get; set; } = new ObservableCollection<Session>();

        private Session _selectedSession;
        public Session SelectedSession
        {
            get { return _selectedSession; }
            set { SetProperty(ref _selectedSession, value); }
        }

        public override async void Start()
        {
            base.Start();

            await LoadSessionsAsync();
        }

        private async Task LoadSessionsAsync()
        {
            BusyMessage = "Loading sessions...";
            IsBusy = true;

            var sessions = await Service.GetAllSessionsAsync();
            Sessions.Clear();
            foreach (var session in sessions)
            {
                Sessions.Add(session);
            }

            IsBusy = false;
        }
    }
}