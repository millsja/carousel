using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carousel.models
{
    public class GameDto
    {
        public string Id { get; set; }
        public IList<FileDto> LocalFiles { get; set; }
        public string Name { get; set; }
        public string ExePath { get; set; }

        public GameDto(
            string id,
            string name,
            IEnumerable<Google.Apis.Drive.v3.Data.File> files)
        {
            Id = id;
            Name = name;
            if (LocalFiles != null)
            {
                LocalFiles = files.Select((f) => new FileDto(f.Id, f.Name)).ToList();
            }
            else
            {
                LocalFiles = new List<FileDto>();
            }
        }

        [JsonConstructor]
        public GameDto()
        {
        }

        public GameDto(string id, string name, string exePath, IList<FileDto> files)
        {
            this.Id = id;
            this.Name = name;
            this.LocalFiles = files;
            this.ExePath = ExePath;
        }

        public GameDto(string id, string name)
        {
            Id = id;
            Name = name;
            LocalFiles = new List<FileDto>();
        }

        public override string ToString()
        {
            return Name;
        }

        public void AddFile(FileDto file)
        {
            this.LocalFiles.Add(file);
        }

        public void Save()
        {
            try
            {
                using (var writer = new StreamWriter(this.GetConfigFile()))
                {
                    var jsonGame = Newtonsoft.Json.JsonConvert.SerializeObject(this);
                    writer.Write(jsonGame);
                }
            }
            catch (IOException)
            {
            }
        }

        public void Load(Func<bool> overwrite = null)
        {
            if (overwrite == null)
            {
                overwrite += () => true;
            }

            try
            {
                using (var reader = new StreamReader(this.GetConfigFile()))
                {
                    var game = Newtonsoft.Json.JsonConvert.DeserializeObject<GameDto>(reader.ReadToEnd());
                    if (overwrite())
                    {
                        this.Id = game.Id;
                        this.Name = game.Name;
                        this.ExePath = game.ExePath;

                        this.LocalFiles = new List<FileDto>();
                        foreach (var file in game.LocalFiles)
                        {
                            this.AddFile(file);
                        }
                    }
                }
            }
            catch (IOException)
            {
            }
        }

        private string GetConfigFile()
        {
            return this.Id + ".dat";
        }
    }
}
