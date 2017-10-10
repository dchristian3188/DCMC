using System.IO;
using NLog;


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

            var directories = Directory.GetDirectories(StartingFolder);
            foreach (string currentDirectoy in directories)
            {
               logger.Info($"Processing folder [{currentDirectoy}]");
                try
                {
                    var files = Directory.GetFiles(currentDirectoy);
                    foreach (string file in files)
                    {
                        UploadFile(file);
                    }
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
            NestUploader.UploadVideoDocumment(videoInfo);

        }

    }
}
