using carousel.models;
using carousel.utilities;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static carousel.utilities.SettingsManager;
using static Google.Apis.Drive.v3.DriveService;
using static Google.Apis.Drive.v3.FilesResource;

namespace carousel
{
    public class CarouselClient
    {
        private LocalMachine _LocalMachine;
        private string _RemoteRootPath;
        private UserCredential _UserCredentials;
        private string _ApplicationName = "Carousel save state manager";

        private CarouselClient(string remotePath, string localMachineId)
        {
            this._RemoteRootPath = remotePath;
            this._LocalMachine = new LocalMachine(localMachineId);
        }

        /// <summary>
        /// attempts to read client settings from file
        /// </summary>
        /// <returns>new client on success</returns>
        public static async Task<CarouselClient> CreateInstance(CancellationTokenSource cts)
        {
            var clientSettings = SettingsManager.Load(Constants.SettingsPath);
            if (clientSettings.HasBlanks)
            {
                throw new NotImplementedException();
            }

            var client = new CarouselClient(clientSettings.RemotePath, clientSettings.LocalMachineId);
            await client.Authorize(clientSettings.UserName, cts);

            return client;
        }

        /// <summary>
        /// prompts user to authorize application to access their Google Drive
        /// </summary>
        /// <param name="userName">user's Google account name</param>
        /// <param name="cancelToken">cancel token object</param>
        /// <returns>task</returns>
        private async Task Authorize(string userName, CancellationTokenSource cts)
        {
            var scopes = new string[] { DriveService.Scope.Drive };

            using (var fileStream = new FileStream(@"resources\client-secret.json", FileMode.Open, FileAccess.Read))
            {
                this._UserCredentials = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(fileStream).Secrets,
                    scopes,
                    userName,
                    cts.Token);
            }
        }

        /// <summary>
        /// revokes application's access to user's Google drive
        /// </summary>
        /// <param name="cancelToken">cancel token</param>
        /// <returns>task</returns>
        public async Task RevokeAuthorization(CancellationToken cancelToken)
        {
            if (_UserCredentials != null)
            {
                await _UserCredentials.RevokeTokenAsync(cancelToken);
            }
        }

        public SettingsDto ToSettings()
        {
            return new SettingsDto()
            {
                LocalMachineId = this._LocalMachine.Id.ToString(),
                RemotePath = this._RemoteRootPath,
                UserName = this._UserCredentials.UserId,
            };
        }

        /// <summary>
        /// gets file metadata list from remote directory
        /// </summary>
        /// <param name="filter">filter to apply to file list</param>
        /// <returns>files list</returns>
        public IList<Google.Apis.Drive.v3.Data.File> GetFilesMetadata(Predicate<Google.Apis.Drive.v3.Data.File> filter)
        {
            if (_UserCredentials != null)
            {
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = this._UserCredentials,
                    ApplicationName = this._ApplicationName,
                });

                var listRequest = service.Files.List();
                listRequest.PageSize = 500;
                listRequest.Fields = "nextPageToken, files(id, name, parents)";

                var fullFileList = new List<Google.Apis.Drive.v3.Data.File>();
                var page = new List<Google.Apis.Drive.v3.Data.File>();

                do
                {
                    var response = listRequest.Execute();
                    page = response.Files.ToList();
                    fullFileList.AddRange(page.Where((f) => filter(f)));
                    var names = page.Select((p) => p.Name).ToList<string>();
                    listRequest.PageToken = response.NextPageToken;
                } while (listRequest.PageToken != null);

                return fullFileList;
                // return fullGamesList.Select((f) => new GameDto(f.Name)).ToList();
            }

            return null;
        }

        /// <summary>
        /// gets the list of files whose immediate parent is the root folder, i.e. the
        /// game folders
        /// </summary>
        /// <returns>list of game data objects</returns>
        public IList<GameDto> GetGamesList()
        {
            var filesList = this.GetFilesMetadata((f) => true);

            var root = filesList.Where((f) => f.Name == Constants.RootPath).First();

            if (root == null)
            {
                return null;
            }

            var rootId = root.Id;

            var gamesList = filesList.Where((f) =>
            {
                return f.Parents != null && f.Parents.Count >= 1 && f.Parents.Last() == rootId;
            }).Select(f => new GameDto(f.Id, f.Name)).ToList();

            foreach (var file in filesList)
            {
                if (file.Parents == null || file.Parents.Count == 0)
                {
                    continue;
                }

                var possibleParents = gamesList.Where(g => file.Parents.Contains(g.Id)).ToList();

                if (possibleParents != null && possibleParents.Count >= 1)
                {
                    possibleParents.First().AddFile(new FileDto(file.Id, file.Name));
                }
            }

            return gamesList;
        }

        /// <summary>
        /// takes a list of game data objects and downloads each to its
        /// respective local path
        /// </summary>
        /// <param name="gameFiles">list of gamedto objects</param>
        public void DownloadFiles(IList<FileDto> gameFiles)
        {
            if (_UserCredentials != null)
            {
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = this._UserCredentials,
                    ApplicationName = this._ApplicationName,
                });

                foreach (var gameFile in gameFiles)
                {
                    using (var filestream = new FileStream(gameFile.LocalPath, FileMode.OpenOrCreate))
                    {
                        var memStream = new MemoryStream();
                        var request = service.Files.Get(gameFile.Id);
                        request.Download(memStream);
                        memStream.CopyTo(filestream);
                    }
                }
            }
        }
    }
}
