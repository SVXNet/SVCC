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

        #region Properties

        public ObservableRangeCollection<Grouping<string, Session>> GroupedSessions { get; set; } = new ObservableRangeCollection<Grouping<string, Session>>();

        private Session _selectedSession;
        public Session SelectedSession
        {
            get { return _selectedSession; }
            set { SetProperty(ref _selectedSession, value); }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { SetProperty(ref _searchText, value); }
        }

        private bool _favoritesOnly;
        public bool FavoritesOnly
        {
            get { return _favoritesOnly; }
            set { SetProperty(ref _favoritesOnly, value); }
        }

        private bool _futureOnly = true;
        public bool FutureOnly
        {
            get { return _futureOnly; }
            set { SetProperty(ref _futureOnly, value); }
        }

        #endregion

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
            var sessions = await Service.GetSessionsAsync(SearchText,FavoritesOnly,FutureOnly, null);

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