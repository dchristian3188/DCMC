using System.IO;
using NLog;
using System.Collections.Generic;


namespace dcmc.shared
{
    public class Uploader
    {
        private NestClient NestUploader;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Uploader(NestClient NestConnection)
        {
            NestUploader = NestConnection;
        }

        public void UploadDirectory(string StartingFolder)
        {
            logger.Info($"Processing folder [{StartingFolder}]");
            var files = Directory.GetFiles(StartingFolder);
            if(files.Length > 0)
            {
                UploadFiles(files);
            }
            
            var directories = Directory.GetDirectories(StartingFolder);
            foreach (string currentDirectoy in directories)
            {
                try
                {
                    UploadDirectory(currentDirectoy);
                }
                catch (System.UnauthorizedAccessException ex)
                {
                    logger.Error($"ERROR CONNECTING TO {currentDirectoy}");
                }
            }
        }

        private void UploadFile(string FileName)
        {
            var videoInfo = new VideoInfo(FileName);
            logger.Info($"Uploding filename [{videoInfo.Name}]");
            NestUploader.UploadVideoDocument(videoInfo);

        }

        private void UploadFiles(string[] FileNames)
        {
            var videosToUpload = new List<VideoInfo>();
            foreach(string file in FileNames)
            {
                logger.Debug($"Getting file information for [{file}]");
                videosToUpload.Add(new VideoInfo(file));
            }

            NestUploader.UploadVideoDocument(videosToUpload);

        }
    }
}
