using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CodeCamp.Core.Helpers;
using CodeCamp.Core.Models;
using MvvmCross.Platform.Platform;
using MvvmCross.Plugins.File;

namespace CodeCamp.Core.Services
{
    public class SvccService : ISvccService
    {
        private const string SessionsUrl = "https://www.siliconvalley-codecamp.com/rest/session/arrayonly";
        private const string SessionsFileName = "sessions.json";
        private const int SessionRefreshAfterMinutes = 5;
        private readonly IMvxJsonConverter _jsonConverter;
        private readonly IMvxFileStore _fileStore;

        public SvccService(IMvxJsonConverter jsonConverter, IMvxFileStore fileStore)
        {
            _jsonConverter = jsonConverter;
            _fileStore = fileStore;
        }

        public async Task<List<Session>> GetAllSessionsAsync()
        {
            var sessions = await GetSessionsAsync();
            return sessions;
        }

        public async Task<List<Session>> GetSessionsAsync(string searchText, bool favoritesOnly, bool futureOnly, int[] tags)
        {
            var sessions = await GetSessionsAsync();
            
            var query =
                sessions.Where(
                    s =>
                        (string.IsNullOrWhiteSpace(searchText) || s.title.ToLower().Contains(searchText) || s.description.ToLower().Contains(searchText) || s.speakersNamesCsv.ToLower().Contains(searchText)) &&
                        (!futureOnly || s.sessionStartDate>=DateTime.Now)  &&
                        s.tagsResults.Any(t=> tags==null || tags.Contains(t.id))
                        );

            return query.ToList();
        }

        public async Task<Session> GetSessionDetailsAsync(int sessionId)
        {
            var sessions = await GetSessionsAsync();
            return sessions.FirstOrDefault(s => s.id == sessionId);
        }

        public async Task<List<Tag>> GetSessionTagsAsync()
        {
            var sessions = await GetSessionsAsync();
            var tags =
                sessions.SelectMany(s => s.tagsResults)
                    .GroupBy(t=>t.id)
                    .Select(grp => new Tag {Id=grp.Key,Name=grp.First().tagName.Trim(),Count=grp.Count() })
                    .OrderBy(t => t.Name);

            return tags.ToList();
        }

        public Task AddSessionToFavorites(int sessionId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveSessionFromFavorites(int sessionId)
        {
            throw new NotImplementedException();
        }

        private async Task<List<Session>> GetSessionsAsync(bool forceRefresh = false)
        {
            if (forceRefresh || (DateTime.UtcNow - Settings.LastSyncTime).TotalMinutes >= SessionRefreshAfterMinutes || !_fileStore.Exists(SessionsFileName))
            {
                await DownloadSessionsAsync();
            }
            var sessionData = _fileStore.OpenRead(SessionsFileName);
           
            var sessions = _jsonConverter.DeserializeObject<Session[]>(sessionData);

#if DEBUG
            var rnd = new Random();
            foreach (var session in sessions)
            {
                var num = rnd.Next(1, 13);
                session.sessionStartDate = GetRandomSessionTime(num);
                session.sessionTime = session.sessionStartDate.ToString("hh:mm tt dddd");
                session.startTime = num.ToString();
            }
#endif

            return new List<Session>(sessions);

        }

        private async Task DownloadSessionsAsync()
        {
            var httpClient = new HttpClient();
            var result = await httpClient.GetAsync(new Uri(SessionsUrl));
            var sessionData = await result.Content.ReadAsStringAsync();
            _fileStore.WriteFile(SessionsFileName, sessionData);
            Settings.LastSyncTime = DateTime.UtcNow;
        }

        /// <summary>
        /// This method is for testing only (since sessions aren't scheduled yet)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private DateTime GetRandomSessionTime(int num)
        {
            switch (num)
            {
                case 1:
                    return new DateTime(2016, 10, 1, 9, 30, 0);
                case 2:
                    return new DateTime(2016, 10, 1, 10, 45, 0);
                case 3:
                    return new DateTime(2016, 10, 1, 12, 30, 0);
                case 4:
                    return new DateTime(2016, 10, 1, 13, 45, 0);
                case 5:
                    return new DateTime(2016, 10, 1, 15, 0, 0);
                case 6:
                    return new DateTime(2016, 10, 1, 16, 15, 0);
                case 7:
                    return new DateTime(2016, 10, 2, 8, 30, 0);
                case 8:
                    return new DateTime(2016, 10, 2, 9, 45, 0);
                case 9:
                    return new DateTime(2016, 10, 2, 11, 00, 0);
                case 10:
                    return new DateTime(2016, 10, 2, 12, 30, 0);
                case 11:
                    return new DateTime(2016, 10, 2, 13, 45, 0);
                case 12:
                    return new DateTime(2016, 10, 2, 15, 0, 0);
            }

            return default(DateTime);
        }

    }
}
