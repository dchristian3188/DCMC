using System;
using Nest;
using NLog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dcmc.shared
{
    public class NestClient
    {
        ElasticClient _client;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public NestClient(string ServerName)
        {
            var settings = new ConnectionSettings(new Uri(ServerName))
                .DefaultIndex("videos");
            _client = new ElasticClient(settings);
        }

        public async void UploadVideoDocumment(VideoInfo NewVideoInfo)
        {
            var result = await _client.IndexAsync(NewVideoInfo);
            if (result.ServerError != null)
            {
                logger.Error(result.ApiCall);
            }
        }

        public async Task<List<VideoInfo>> GetVideoDocument()
        {
            logger.Info("Starting Search");
            var searchResponse = await _client.SearchAsync<VideoInfo>(s => s
                .Query(q => q
                    .MatchAll()
                 )
                .Size(500)
            );


            if (searchResponse.ServerError == null)
            {
                logger.Info($"Returning [{searchResponse.Hits}] hits");
                return new List<VideoInfo>(searchResponse.Documents);
            }
            else
            {
                logger.Error($"No Results returned [{searchResponse.DebugInformation}]");
                return new List<VideoInfo>();
            }
        }

        public VideoInfo GetVideoDocumentByID(string ID)
        {
            if(string.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("ID cannot be empty");
            }
            var getRequest = new GetRequest("videos", "videoinfo", ID);
            var getResponse = _client.Get<VideoInfo>(getRequest);

            if (getResponse.Found)
            {
                logger.Info($"Found my for doc ID {ID}");
                return getResponse.Source;
            }
            else
            {
                logger.Error($"Not match found for doc ID {ID}");
                return new VideoInfo();
            }
        }
    }
}