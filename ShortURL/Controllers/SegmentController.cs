using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortURL.ViewModel;

namespace ShortURL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentController : ControllerBase
    {
        private readonly IURLSegmentService service;
        public SegmentController(IURLSegmentService _service)
        {
            service = _service;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var result = service.GetAll();
                return Ok(result);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] SegmentDTO Model)
        {
            try
            {
                Uri uriResult;
                bool result = Uri.TryCreate(Model.url, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                if (result)
                {
                    var checksegment = service.CheckURLExsitance(Model.url);
                    if(string.IsNullOrEmpty(checksegment))
                    {
                        var segment = service.AddSegment(Model.url);
                        return Ok(true);
                    }
                    else
                    {
                        return Ok(true);
                    }
                  
                }
                else
                {
                    return StatusCode(400, "URL is not valid");
                }
            }
            catch(Exception e )
            {
                return StatusCode(500, e.Message);
            }
        }


    }
}