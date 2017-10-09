using System;
using System.Collections.Generic;
using Nest;

namespace dcmc.shared
{
    public class NestClient
    {
        ElasticClient _client;

        public NestClient(string ServerName)
        {
            var settings = new ConnectionSettings(new Uri(ServerName))
                .DefaultIndex("videos");
            _client = new ElasticClient(settings);
        }

        public async void UploadVideoDocumment(VideoInfo NewVideoInfo)
        {
            var result = await _client.IndexAsync(NewVideoInfo);
            Console.WriteLine(result);
        }

        public async void AddSeedData()
        {
            var newVideo = new VideoInfo(@"C:\somePath\blah\Hi.mp4");
            
            var result =  await _client.IndexAsync(newVideo);
            return;
        }

        //public IEnumerable<Video> GetAllVideos()
        //{
        //}
    }
}