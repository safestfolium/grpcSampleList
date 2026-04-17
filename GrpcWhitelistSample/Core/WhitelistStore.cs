using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GrpcWhitelistSample.Core
{
    public class AccessAttempt
    {
        public string Ip { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Allowed { get; set; }
    }

    public static class WhitelistStore
    {
        private static readonly object _lock = new object();
        private static bool _whitelistEnabled = true;
        private static List<string> _allowedClients = new List<string>();
        private static List<AccessAttempt> _history = new List<AccessAttempt>();

        public static event Action StateChanged;

        private static string ConfigFilePath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "whitelist_config.json");
            }
        }

        public static void Initialize()
        {
            lock (_lock)
            {
                if (File.Exists(ConfigFilePath))
                {
                    try
                    {
                        string json = File.ReadAllText(ConfigFilePath);
                        var config = JsonConvert.DeserializeObject<WhitelistConfig>(json);
                        if (config != null)
                        {
                            _whitelistEnabled = config.WhitelistEnabled;
                            _allowedClients = config.AllowedClients != null
                                ? new List<string>(config.AllowedClients)
                                : new List<string>();
                        }
                    }
                    catch
                    {
                        // Use defaults if config cannot be loaded
                    }
                }
            }
        }

        private static void SaveConfig()
        {
            try
            {
                var config = new WhitelistConfig
                {
                    WhitelistEnabled = _whitelistEnabled,
                    AllowedClients = new List<string>(_allowedClients)
                };
                string json = JsonConvert.SerializeObject(config, Formatting.Indented);
                File.WriteAllText(ConfigFilePath, json);
            }
            catch
            {
                // Best-effort save
            }
        }

        public static bool IsWhitelistEnabled()
        {
            lock (_lock) { return _whitelistEnabled; }
        }

        public static void SetWhitelistEnabled(bool enabled)
        {
            lock (_lock)
            {
                _whitelistEnabled = enabled;
                SaveConfig();
            }
            FireStateChanged();
        }

        public static List<string> GetAllowedClients()
        {
            lock (_lock) { return new List<string>(_allowedClients); }
        }

        public static void AddAllowedClient(string ip)
        {
            lock (_lock)
            {
                if (!_allowedClients.Contains(ip))
                {
                    _allowedClients.Add(ip);
                    SaveConfig();
                }
            }
            FireStateChanged();
        }

        public static void RemoveAllowedClient(string ip)
        {
            lock (_lock)
            {
                _allowedClients.Remove(ip);
                SaveConfig();
            }
            FireStateChanged();
        }

        public static void RecordAttempt(string ip, bool allowed)
        {
            lock (_lock)
            {
                _history.Add(new AccessAttempt
                {
                    Ip = ip,
                    Timestamp = DateTime.Now,
                    Allowed = allowed
                });
            }
            FireStateChanged();
        }

        public static List<AccessAttempt> GetHistory()
        {
            lock (_lock)
            {
                var copy = new List<AccessAttempt>(_history);
                copy.Sort((a, b) => b.Timestamp.CompareTo(a.Timestamp));
                return copy;
            }
        }

        private static void FireStateChanged()
        {
            Action handler = StateChanged;
            if (handler != null) handler();
        }

        private class WhitelistConfig
        {
            public bool WhitelistEnabled { get; set; }
            public List<string> AllowedClients { get; set; }
        }
    }
}
