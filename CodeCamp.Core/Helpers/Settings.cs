// Helpers/Settings.cs

using System;
using System.Collections.Generic;
using CodeCamp.Core.Models;
using MvvmCross.Platform;
using EShyMedia.MvvmCross.Plugins.Settings;
using Newtonsoft.Json;

namespace CodeCamp.Core.Helpers
{
    public static class Settings
    {
        /// <summary>
        /// Simply setup your settings once when it is initialized.
        /// </summary>
        private static ISettings m_Settings;
        private static ISettings AppSettings => m_Settings ?? (m_Settings = Mvx.GetSingleton<ISettings>());

        public static DateTime LastSyncTime
        {
            get { return AppSettings.GetValueOrDefault(nameof(LastSyncTime), DateTime.MinValue); }
            set { AppSettings.AddOrUpdateValue(nameof(LastSyncTime), value); }
        }

        public static List<int> FavoriteSessionIds
        {
            get
            {
                var json = AppSettings.GetValueOrDefault(nameof(FavoriteSessionIds), string.Empty);
                return string.IsNullOrWhiteSpace(json) ? null : JsonConvert.DeserializeObject<List<int>>(json);
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(FavoriteSessionIds), JsonConvert.SerializeObject(value));
            }

        }

    }
}