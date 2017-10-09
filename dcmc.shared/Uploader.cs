using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace dcmc.shared
{
    public class Uploader
    {
        private NestClient NestUploader;

        public Uploader(NestClient NestConnection)
        {
            NestUploader = NestConnection;
        }

        public void UploadDirectory(string StartingFolder)
        {

            var directories = Directory.GetDirectories(StartingFolder);
            foreach (string currentDirectoy in directories)
            {
                //Console.WriteLine($"Processing folder [{currentDirectoy}]");
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
                    Console.WriteLine($"ERROR CONNECTING TO {currentDirectoy}");
                }
            }
        }

        private void UploadFile(string FileName)
        {
            var videoInfo = new VideoInfo(FileName);
            //Console.WriteLine($"Uploding filename [{videoInfo.Name}]");
            NestUploader.UploadVideoDocumment(videoInfo);

        }

    }
}
