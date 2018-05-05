using carousel.models;
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
using static Google.Apis.Drive.v3.DriveService;
using static Google.Apis.Drive.v3.FilesResource;

namespace carousel
{
    public class CarouselClient
    {
        private string _GoogleDriveApiKey;
        private UserCredential _UserCredentials;
        private string _ApplicationName = "Carousel save state manager";

        private CarouselClient()
        {
        }

        public static async Task<CarouselClient> CreateInstance(string userName)
        {
            var client = new CarouselClient();
            await client.Authorize(userName, CancellationToken.None);
            return client;
        }

        private async Task Authorize(string userName, CancellationToken cancelToken)
        {
            var scopes = new string[] { DriveService.Scope.Drive };

            using (var fileStream = new FileStream(@"resources\client-secret.json", FileMode.Open, FileAccess.Read))
            {
                this._UserCredentials = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(fileStream).Secrets,
                    scopes,
                    userName,
                    cancelToken);
            }
        }

        public async Task RevokeAuthorization(CancellationToken cancelToken)
        {
            if (_UserCredentials != null)
            {
                await _UserCredentials.RevokeTokenAsync(cancelToken);
            }
        }

        public IList<GameDto> GetGamesList()
        {
            if (_UserCredentials != null)
            {
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = this._UserCredentials,
                    ApplicationName = this._ApplicationName,
                });

                var listRequest = service.Files.List();
                listRequest.PageSize = 10;
                listRequest.Fields = "nextPageToken, files(id, name)";


                var files = listRequest.Execute().Files;

                return files.Select((f) => new GameDto(f.Name)).ToList();
            }

            return null;
        }
    }
}
