using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]  
    //  public class CommandsController ==>>   [Route("api/commands")]
    // http://<server_address>/api/<controller_name> 

    [ApiController]   //following out-of-the-box
    public class CommandsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"this", "is", "hard", "coded"};
        }

        //Microsoft.AspNetCore.Mvc.
    }
}