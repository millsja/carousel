using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carousel.utilities
{
    public static class SettingsManager
    {
        /// <summary>
        /// attempts to load settings from file. returns blank settings file on failure
        /// </summary>
        /// <param name="settingsPath">path of settings file</param>
        /// <returns></returns>
        public static SettingsDto Initialize(string settingsPath, Func<string> userNameInput)
        {
            string jsonSettings = string.Empty;

            try
            {
                using (var reader = new StreamReader(settingsPath))
                {
                    jsonSettings = reader.ReadToEnd();
                }

                var settings = Newtonsoft.Json.JsonConvert.DeserializeObject<SettingsDto>(jsonSettings);

                if (string.IsNullOrEmpty(settings.UserName))
                {
                    throw new Exception("Error: username required");
                }

                return settings;
            }
            catch (Exception)
            {
                string userName = string.Empty;
                if (userNameInput != null)
                {
                    userName = userNameInput();
                }

                var settings = new SettingsDto()
                {
                    LocalMachineId = Guid.NewGuid().ToString(),
                    RemotePath = Constants.RootPath,
                    UserName = userName,
                };

                var newJsonSettings = Newtonsoft.Json.JsonConvert.SerializeObject(settings);

                using (var writer = new StreamWriter(Constants.SettingsPath))
                {
                    writer.Write(newJsonSettings);
                }

                return settings;
            }
        }

        /// <summary>
        /// writes carousel client to settings file
        /// </summary>
        /// <param name="settingsPath">path to settings file</param>
        public static void Write(SettingsDto settings, string settingsPath)
        {
            try
            {
                var jsonSettings = Newtonsoft.Json.JsonConvert.SerializeObject(settings);

                using (var writer = new StreamWriter(settingsPath))
                {
                    writer.Write(jsonSettings);
                }
            }
            catch (Exception)
            {
            }
        }

        [JsonObject(MemberSerialization.OptIn)]
        public class SettingsDto
        {
            [JsonProperty]
            public string UserName = string.Empty;

            [JsonProperty]
            public string LocalMachineId = string.Empty;

            [JsonProperty]
            public string RemotePath = string.Empty;

            public bool HasBlanks
            {
                get
                {
                    return (
                        string.IsNullOrEmpty(this.UserName) ||
                        string.IsNullOrEmpty(this.LocalMachineId) ||
                        string.IsNullOrEmpty(this.RemotePath));
                }
            }
        }
    }
}
