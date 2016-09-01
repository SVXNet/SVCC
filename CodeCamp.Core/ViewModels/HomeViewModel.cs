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

        private List<Tag> _tags;

        public List<Tag> Tags
        {
            get { return _tags; }
            set { SetProperty(ref _tags, value); }
        }


        #endregion

        public override async void Start()
        {
            base.Start();

            await LoadSessionsAsync();

            await LoadTagsAsync();
        }

        private async Task LoadSessionsAsync()
        {
            BusyMessage = "Loading sessions...";
            IsBusy = true;

            //var sessions = await Service.GetAllSessionsAsync();
            var tags = Tags?.Where(t => t.Selected).Select(t => t.Id).ToArray();
            var sessions = await Service.GetSessionsAsync(SearchText,FavoritesOnly,FutureOnly, tags);

            //sort and group sessions
            var sorted = from session in sessions
                         orderby session.startTime
                         group session by session.sessionTime into sessionGroup
                         select new Grouping<string, Session>(sessionGroup.Key, sessionGroup);
            GroupedSessions.Clear();
            GroupedSessions.AddRange(sorted);

            IsBusy = false;
        }

        private async Task LoadTagsAsync()
        {
            BusyMessage = "Loading tags...";
            IsBusy = true;
            Tags = await Service.GetSessionTagsAsync();
            IsBusy = false;
        }

    }
}