using System;
using System.Collections.Generic;

namespace dcmc.shared
{
    public class VideoInfo
    {
        public VideoInfo(string VideoPath)
        {
            Id = VideoPath;
            Tags = GenerateTags();
            Name = System.IO.Path.GetFileNameWithoutExtension(VideoPath);
            Extension = System.IO.Path.GetExtension(VideoPath);
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public List<string> Tags { get; set; }

        private List<string> GenerateTags()
        {
            var tagList = new List<string>();
            tagList.AddRange(Id.Split('\\'));
            return tagList;
        }
    }
}