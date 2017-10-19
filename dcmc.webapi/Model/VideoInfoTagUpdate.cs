using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dcmc.webapi.Model
{
    public class VideoInfoTagUpdate
    {
        public string FilePath { get; set; }
        public List<string> Tags { get; set; }
    }
}
