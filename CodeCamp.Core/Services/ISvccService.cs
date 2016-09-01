using System.Collections.Generic;
using System.Threading.Tasks;
using CodeCamp.Core.Models;

namespace CodeCamp.Core.Services
{
    public interface ISvccService
    {
        /*
         SyncData (download sessions from server and save locally, check when we last downloaded, unless a refresh is forced don't download if data is recent)
         GetSessions (get sessions grouped by date/time, filtered by all possible filters) 
         GetSession(id)
            Add/Remove from favorites (use Settings with array of session ids)
             
             */
        Task<List<Session>> GetAllSessionsAsync();

        Task<List<Session>> GetSessionsAsync(string searchText, bool favoritesOnly, bool futureOnly, string[] tags);

        Task<Session> GetSessionDetailsAsync(int sessionId);

        Task AddSessionToFavorites(int sessionId);

        Task RemoveSessionFromFavorites(int sessionId);
    }
}