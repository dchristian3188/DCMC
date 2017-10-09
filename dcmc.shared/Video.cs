using System;
using System.Collections.Generic;

namespace dcmc.shared
{
    public class Video
    {
        public Guid Id {get;set;}
        public string Path {get;set;}
        public string Name {get;set;}
        public List<string> Tags {get;set;}
        public Video()
        {
            Id = Guid.NewGuid();
            Tags = new List<string>();
        }
    }
}