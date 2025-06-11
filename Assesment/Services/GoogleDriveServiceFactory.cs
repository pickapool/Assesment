using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Assesment.Services
{
    public class GoogleDriveServiceFactory
    {
        private readonly string _credentialsPath = "credentials.json";
        private readonly string _tokenPath = "token.json";

        public async Task<DriveService> CreateAsync()
        {
            UserCredential credential;

            using (var stream = new FileStream(_credentialsPath, FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    new[] { DriveService.Scope.Drive },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(_tokenPath, true));
            }

            return new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "iCredit",
            });
        }
    }
}
