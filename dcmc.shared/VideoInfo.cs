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
            Id = Utility.MD5Hash(VideoPath);
            FilePath = VideoPath;
            Tags = GenerateTags();
            Name = Path.GetFileNameWithoutExtension(VideoPath);
            Extension = fileInfo.Extension;
            SizeMB = fileInfo.Exists ? (fileInfo.Length / 1048576) : 0; //Convert bytes to MB
        }

        public string Id { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public long SizeMB { get; set; }

        public List<string> Tags { get; set; }

        private List<string> GenerateTags()
        {
            var tagList = new List<string>();
            tagList.AddRange(FilePath.Split('\\'));
            return tagList;
        }
    }
}