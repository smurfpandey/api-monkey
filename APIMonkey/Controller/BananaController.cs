using APIMonkey.Code;
using APIMonkey.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace APIMonkey.Controller
{
    public class BananaController : ApiController
    {
        [Route("banana/{bananaId}"), HttpGet]
        public IHttpActionResult GetABanana(string bananaId)
        {
            try
            {
                if (string.IsNullOrEmpty(bananaId))
                {
                    return NotFound();
                }

                Banana objBanana = new BananaManager().GetMyBanana(bananaId);

                if (objBanana == null)
                {
                    return NotFound();
                }

                return Ok(objBanana.flesh);
            }
            catch (Exception ex)
            {
                Logger.TraceError(ex, Request.RequestUri.ToString());
                return InternalServerError();
            }
        }

        [Route("banana"), HttpPut]
        public IHttpActionResult PlantABanana([FromBody]dynamic objBananaFlesh)
        {
            try
            {
                Banana newBanana = new BananaManager().PlantABanana(objBananaFlesh);
                
                if (newBanana == null)
                {
                    return InternalServerError();
                }

                string location = Request.RequestUri + "/" + newBanana._key.ToString().ToLower();
                return Created<Banana>(location, newBanana);
            }
            catch (Exception ex)
            {
                Logger.TraceError(ex, Request.RequestUri.ToString());
                return InternalServerError();
            }
        }


    }
}
