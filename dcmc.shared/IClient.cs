using System;
using System.Collections.Generic;
using System.Text;
using Nest;
using NLog;
using System.Threading.Tasks;

namespace dcmc.shared
{
    public interface IClient
    {
        void UploadVideoDocument(VideoInfo NewVideoInfo);

        void UploadVideoDocument(List<VideoInfo> NewVideoInfo);

        Task<List<VideoInfo>> GetVideoDocument();

        VideoInfo GetVideoDocumentByID(string ID);
    }
}
