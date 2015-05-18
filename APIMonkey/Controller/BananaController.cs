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
        public async Task<IHttpActionResult> GetABanana(string bananaId)
        {
            try
            {
                if (string.IsNullOrEmpty(bananaId))
                {
                    return NotFound();
                }

                var myBanana = new BananaManager().GetMyBanana(bananaId);

                await Task.Run(() => myBanana);

                Banana objBanana = myBanana.Result;

                if (objBanana == null)
                {
                    return NotFound();
                }

                return Ok(myBanana);
            }
            catch (Exception ex)
            {
                Logger.TraceError(ex, Request.RequestUri.ToString());
                return InternalServerError();
            }
        }

        [Route("banana"), HttpPut]
        public async Task<IHttpActionResult> PlantABanana([FromBody]dynamic objBananaFlesh)
        {
            try
            {
                var myBanana = new BananaManager().PlantABanana(objBananaFlesh);

                await Task.Run(() => myBanana);

                Banana newBanana = myBanana.Result;

                if (newBanana == null)
                {
                    return InternalServerError();
                }

                string location = Request.RequestUri + "/" + newBanana.Id.ToString().ToLower();
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
