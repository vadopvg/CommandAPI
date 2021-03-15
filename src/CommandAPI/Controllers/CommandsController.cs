using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Data;
using CommandAPI.Models;
using AutoMapper;
using CommandAPI.Dtos;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]  
    //  public class CommandsController ==>>   [Route("api/commands")]
    // http://<server_address>/api/<controller_name> 

    [ApiController]   //following out-of-the-box
    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIRepo _repository;
        private readonly IMapper _mapper;  //

       // public CommandsController(ICommandAPIRepo repository)
        public CommandsController(ICommandAPIRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper; //
        }

        [HttpGet]
        // public ActionResult<IEnumerable<Command>> GetAllCommands()
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            // return Ok(commandItems);
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        [HttpGet("{id}")]
        // public ActionResult<Command> GetCommandById(int id)
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            // return Ok(commandItem);
            return Ok(_mapper.Map<CommandReadDto>(commandItem));
        }
/***
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"this", "is", "hard", "coded"};
        }
***/
        //Microsoft.AspNetCore.Mvc.
    }
}