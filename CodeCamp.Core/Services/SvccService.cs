using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CodeCamp.Core.Models;
using MvvmCross.Platform.Platform;

namespace CodeCamp.Core.Services
{
    public class SvccService : ISvccService
    {
        private readonly IMvxJsonConverter _jsonConverter;

        public SvccService(IMvxJsonConverter jsonConverter)
        {
            _jsonConverter = jsonConverter;
        }

        public async Task<List<Session>> GetAllSessionsAsync()
        {
            var url = "https://www.siliconvalley-codecamp.com/rest/session/arrayonly";

            var httpClient = new HttpClient();
            var result = await httpClient.GetAsync(new Uri(url));
            var sessions = _jsonConverter.DeserializeObject<Session[]>(await result.Content.ReadAsStringAsync());

            return new List<Session>(sessions);
        }
    }
}
