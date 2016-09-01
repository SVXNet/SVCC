using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CodeCamp.Core.Helpers;
using CodeCamp.Core.Models;
using CodeCamp.Core.Services;

namespace CodeCamp.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel(ISvccService service) : base(service)
        {
        }

        //public ObservableRangeCollection<Session> Sessions { get; set; } = new ObservableRangeCollection<Session>();

        public ObservableRangeCollection<Grouping<string, Session>> GroupedSessions { get; set; } = new ObservableRangeCollection<Grouping<string, Session>>();

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

            //var sessions = await Service.GetAllSessionsAsync();
            var sessions = await Service.GetSessionsAsync("", false, false, null);

            //sort and group sessions
            var sorted = from session in sessions
                         orderby session.startTime
                         group session by session.sessionTime into sessionGroup
                         select new Grouping<string, Session>(sessionGroup.Key, sessionGroup);
            GroupedSessions.Clear();
            GroupedSessions.AddRange(sorted);

            IsBusy = false;
        }

    }
}