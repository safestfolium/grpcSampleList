using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GrpcShared
{
    public static class WhitelistStore
    {
        private static readonly object _lock = new object();
        private static bool _whitelistEnabled = true;
        private static List<string> _allowedClients = new List<string>();
        private static List<AccessAttempt> _history = new List<AccessAttempt>();

        private static readonly string _configFile = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "whitelist_config.json");

        public static event Action StateChanged;

        public static void Initialize()
        {
            lock (_lock)
            {
                if (!File.Exists(_configFile)) return;

                try
                {
                    string json = File.ReadAllText(_configFile);
                    WhitelistConfig config = JsonConvert.DeserializeObject<WhitelistConfig>(json);
                    if (config != null)
                    {
                        _whitelistEnabled = config.WhitelistEnabled;
                        _allowedClients = config.AllowedClients ?? new List<string>();
                    }
                }
                catch
                {
                    // ignore corrupt config
                }
            }
        }

        public static bool WhitelistEnabled
        {
            get
            {
                lock (_lock)
                {
                    return _whitelistEnabled;
                }
            }
        }

        public static void SetWhitelistEnabled(bool enabled)
        {
            lock (_lock)
            {
                _whitelistEnabled = enabled;
                SaveConfig();
            }
            OnStateChanged();
        }

        public static List<string> GetAllowedClients()
        {
            lock (_lock)
            {
                return new List<string>(_allowedClients);
            }
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
            OnStateChanged();
        }

        public static void RemoveAllowedClient(string ip)
        {
            lock (_lock)
            {
                if (_allowedClients.Contains(ip))
                {
                    _allowedClients.Remove(ip);
                    SaveConfig();
                }
            }
            OnStateChanged();
        }

        public static void RecordAttempt(string ip, bool allowed)
        {
            lock (_lock)
            {
                _history.Add(new AccessAttempt { Ip = ip, Timestamp = DateTime.Now, Allowed = allowed });
            }
            OnStateChanged();
        }

        public static List<AccessAttempt> GetHistory()
        {
            lock (_lock)
            {
                List<AccessAttempt> sorted = new List<AccessAttempt>(_history);
                sorted.Sort((a, b) => b.Timestamp.CompareTo(a.Timestamp));
                return sorted;
            }
        }

        private static void SaveConfig()
        {
            try
            {
                WhitelistConfig config = new WhitelistConfig
                {
                    WhitelistEnabled = _whitelistEnabled,
                    AllowedClients = new List<string>(_allowedClients)
                };
                string json = JsonConvert.SerializeObject(config, Formatting.Indented);
                File.WriteAllText(_configFile, json);
            }
            catch
            {
                // ignore write errors
            }
        }

        private static void OnStateChanged()
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

    public class AccessAttempt
    {
        public string Ip { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Allowed { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}]  {1}  {2}",
                Timestamp.ToString("yyyy-MM-dd HH:mm:ss"),
                Ip,
                Allowed ? "√ Allowed" : "× Denied");
        }
    }
}
