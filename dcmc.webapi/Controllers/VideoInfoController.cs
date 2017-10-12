using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dcmc.shared;
using dcmc.webapi.Model;

namespace dcmc.webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/VideoInfo")]
    public class VideoInfoController : Controller
    {
        NestClient _nestClient;
        public VideoInfoController()
        {
            _nestClient = new NestClient("http://beast2:9200");
        }

        // GET: api/VideoInfo
        [HttpGet]
        public async Task<List<VideoInfo>> Get()
        {
            return await _nestClient.GetVideoDocument();
        }


        // GET: api/VideoInfo/5
        [HttpGet("{id}", Name = "Get")]
        public VideoInfo Get(string id)
        {
            return _nestClient.GetVideoDocumentByID(id);
        }

        // POST: api/VideoInfo
        [HttpPost]
        public ActionResult Post([FromBody]VideoInfoNameCreate VideoName)
        {
            if (VideoName.FilePath == null)
            {
                return BadRequest("Filepath cannot be null");

            }
            var video = new VideoInfo(VideoName.FilePath);
             _nestClient.UploadVideoDocument(video);
            return NoContent();
        }

        // PUT: api/VideoInfo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
