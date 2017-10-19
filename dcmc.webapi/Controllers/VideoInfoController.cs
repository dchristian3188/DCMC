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
        IClient _client;
        public VideoInfoController(IClient serviceClient)
        {
            _client = serviceClient;
        }

        // GET: api/VideoInfo
        [HttpGet]
        public async Task<List<VideoInfo>> Get()
        {
            return await _client.GetVideoDocument();
        }


        // GET: api/VideoInfo/5
        [HttpGet("{id}", Name = "Get")]
        public VideoInfo Get(string id)
        {
            return _client.GetVideoDocumentByID(id);
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
             _client.UploadVideoDocument(video);
            return NoContent();
        }

        // POST: api/VideoInfo
        [HttpPatch]
        public ActionResult Post([FromBody]VideoInfoTagUpdate VideoInfoWithTags)
        {
            if (VideoInfoWithTags.FilePath == null)
            {
                return BadRequest("Filepath cannot be null");

            }
            var video = new VideoInfo(VideoInfoWithTags.FilePath,VideoInfoWithTags.Tags);
            _client.UploadVideoDocument(video);
            return NoContent();
        }

        // PUT: api/VideoInfo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            throw new NotSupportedException("Posting by ID not supported at this time");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotSupportedException("Deleting by ID not supported at this time");
        }
    }
}
