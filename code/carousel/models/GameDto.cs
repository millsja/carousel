using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace carousel.models
{
    public class GameDto
    {
        public string Id { get; set; }
        public IList<FileDto> LocalFiles { get; set; }
        public string Name { get; set; }
        public string ExePath { get; set; }

        /// <summary>
        /// initializes new gamedto object
        /// </summary>
        /// <param name="id">string google drive api id</param>
        /// <param name="name">string filename</param>
        /// <param name="files">list of google drive api files</param>
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

        /// <summary>
        /// simple constructor for serializing json object
        /// </summary>
        [JsonConstructor]
        public GameDto()
        {
        }

        // public GameDto(string id, string name, string exePath, IList<FileDto> files)
        // {
        //     this.Id = id;
        //     this.Name = name;
        //     this.LocalFiles = files;
        //     this.ExePath = ExePath;
        // }

        /// <summary>
        /// initializes new gamedto object
        /// </summary>
        /// <param name="id">string google drive api id</param>
        /// <param name="name">string filename</param>
        public GameDto(string id, string name)
        {
            Id = id;
            Name = name;
            LocalFiles = new List<FileDto>();
        }

        /// <summary>
        /// returns filename
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// add file to gamedto's list of local files
        /// </summary>
        /// <param name="file"></param>
        public void AddFile(FileDto file)
        {
            this.LocalFiles.Add(file);
        }

        /// <summary>
        /// save current gamedto to local config file
        /// </summary>
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

        /// <summary>
        /// loads gamedto object from local config file, which is determined by
        /// existing game objects id
        /// </summary>
        /// <param name="overwrite">predicate to overwrite this game object</param>
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

        /// <summary>
        /// gets the filename for the local config file
        /// </summary>
        /// <returns>string filename of local config file</returns>
        private string GetConfigFile()
        {
            return this.Id + ".dat";
        }

        /// <summary>
        /// backs up local and downloads remote files
        /// </summary>
        /// <param name="client">carousel client</param>
        public void SetupGame(CarouselClient client)
        {
            BackupLocalFiles();
            DownloadRemoteFiles(client);
        }

        /// <summary>
        /// starts game process and passes cancellation action to process exit
        /// s.t. we can follow up on thread completion
        /// </summary>
        /// <param name="cts">cancellation token</param>
        /// <param name="a">action run on thread completion</param>
        /// <returns>task</returns>
        public async Task StartGame(CancellationTokenSource cts, Action<CancellationTokenSource> a)
        {
            StartProcess(cts, a);
        }

        /// <summary>
        /// starts game process and passes cancellation action to process exit
        /// s.t. we can follow up on thread completion
        /// </summary>
        /// <param name="cts">cancellation token</param>
        /// <param name="a">action run on thread completion</param>
        /// <returns>task</returns>
        private async Task StartProcess(CancellationTokenSource cts, Action<CancellationTokenSource> a)
        {
            if (!string.IsNullOrEmpty(this.ExePath))
            {
                Process p = new Process();
                p.StartInfo.WorkingDirectory = Path.GetDirectoryName(this.ExePath);
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "/c \"" + this.ExePath + "\"";
                p.EnableRaisingEvents = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Exited += (sender, e) =>
                {
                    a(cts);
                };
                p.Start();
            }
        }

        /// <summary>
        /// takes each of the games local files and creates a copy
        /// with suffix .bak and some incrementing number if that
        /// .bak already exists
        /// </summary>
        private void BackupLocalFiles()
        {
            foreach (var file in this.LocalFiles)
            {
                var existingName = file.LocalPath;

                if (!File.Exists(existingName))
                {
                    continue;
                }

                var rootBackupName = existingName + ".bak";
                var backupName = string.Copy(rootBackupName);

                for (int i = 1; File.Exists(backupName); i++)
                {
                    backupName = rootBackupName + i.ToString();
                }

                try
                {
                    File.Copy(existingName, backupName, true);
                }
                catch (IOException)
                {
                }
            }
        }

        /// <summary>
        /// deletes all .bak files in each local file's directory
        /// </summary>
        /// <returns>task</returns>
        public async Task CleanupLocalBackups()
        {
            await Task.Run(() =>
            {
                foreach (var gameFile in this.LocalFiles)
                {
                    var dir = Path.GetDirectoryName(gameFile.LocalPath);
                    var files = Directory.GetFiles(dir);
                    foreach (var file in files)
                    {
                        // if (file.EndsWith(".bak"))
                        if (Regex.IsMatch(file, @"bak\d+$|bak$"))
                        {
                            File.Delete(file);
                        }
                    }
                }
            });
        }

        /// <summary>
        /// downloads each remote game file to its respective local path
        /// </summary>
        /// <param name="client">carousel client</param>
        private void DownloadRemoteFiles(CarouselClient client)
        {
            client.DownloadFiles(this.LocalFiles);
        }

        /// <summary>
        /// uploads game's local files to remote directory 
        /// </summary>
        /// <param name="client">carousel client</param>
        public async Task UploadLocalFiles(CarouselClient client)
        {
            client.UploadFiles(this.LocalFiles, this.Id);
        }
    }
}
