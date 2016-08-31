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

        public ObservableRangeCollection<Session> Sessions { get; set; } = new ObservableRangeCollection<Session>();

        public IEnumerable<Grouping<string, Session>> GroupedSessions { get; set; }

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
#if DEBUG
            var rnd = new Random();
            foreach (var session in sessions)
            {
                var num = rnd.Next(1, 13);
                session.sessionTime = GetRandomSessionTime(num);
                session.startTime = num.ToString();
            }
#endif
            //sort and group sessions
            var sorted = from session in sessions
                         orderby session.startTime
                         group session by session.sessionTime into sessionGroup
                         select new Grouping<string, Session>(sessionGroup.Key, sessionGroup);
            GroupedSessions = sorted;

            Sessions.Clear();
            Sessions.AddRange(sessions);

            IsBusy = false;
        }

        private string GetRandomSessionTime(int num)
        {
            switch (num)
            {
                case 1:
                    return "9:30 AM Saturday";
                case 2:
                    return "10:45 AM Saturday";
                case 3:
                    return "12:30 AM Saturday";
                case 4:
                    return "1:45 AM Saturday";
                case 5:
                    return "3:00 AM Saturday";
                case 6:
                    return "4:15 AM Saturday";
                case 7:
                    return "8:30 AM Sunday";
                case 8:
                    return "9:45 AM Sunday";
                case 9:
                    return "11:00 AM Sunday";
                case 10:
                    return "12:30 AM Sunday";
                case 11:
                    return "1:45 AM Sunday";
                case 12:
                    return "3:00 AM Sunday";
            }

            return "";
        }
    }
}