using System.IO;
using System.Collections.Generic;

namespace dcmc.shared
{
    public class VideoInfo
    {
        public VideoInfo()
        { }

        public VideoInfo(string VideoPath)
        {
            var fileInfo = new FileInfo(VideoPath);
            Id = VideoPath;
            Tags = GenerateTags();
            Name = Path.GetFileNameWithoutExtension(VideoPath);
            Extension = fileInfo.Extension;
            Size = fileInfo.Length;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public List<string> Tags { get; set; }

        private List<string> GenerateTags()
        {
            var tagList = new List<string>();
            tagList.AddRange(Id.Split('\\'));
            return tagList;
        }
    }
}