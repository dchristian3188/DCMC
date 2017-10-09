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
                .DefaultIndex("Video");
            _client = new ElasticClient(settings);
        }

        public async void AddSeedData()
        {
            var newVideo = new Video
            {
                Path = @"C:\somePath\blah\Hi.mp4",
                Name = "SuperBad"
            };
            newVideo.Tags.Add("Comedy");
            newVideo.Tags.Add("Mature");

            var result =  await _client.IndexAsync(newVideo);
            return;
        }

        //public IEnumerable<Video> GetAllVideos()
        //{
        //}
    }
}