using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GPI.Data;
using GPI.Dtos;
using GPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GPI.Controllers
{
    [Route("api/logiciels")]
    [ApiController]
    public class LogicielsController : ControllerBase
    {
        private readonly ILogicielRepo _repository;
        private readonly IMapper _mapper;

        public LogicielsController(ILogicielRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/Logiciels
        [HttpGet]
        public ActionResult<IEnumerable<LogicielReadDto>> GetAllLogiciels()
        {
            var logicielItems = _repository.GetAllLogiciels();

            return Ok(_mapper.Map<IEnumerable<LogicielReadDto>>(logicielItems));
        }


        //GET api/Logiciels/{id}
        [HttpGet("{id}", Name = "GetLogicielById")]
        public ActionResult<LogicielReadDto> GetLogicielById(int id)
        {
            var logicielItem = _repository.GetLogicielById(id);
            if (logicielItem != null)
            {
                return Ok(_mapper.Map<LogicielReadDto>(logicielItem));
            }
            return NotFound();
        }


        //POST api/Logiciels
        [HttpPost]
        public ActionResult<LogicielReadDto> CreateLogiciel(LogicielCreateDto logicielCreateDto)
        {
            var logicielModel = _mapper.Map<Logiciel>(logicielCreateDto);
            _repository.CreateLogiciel(logicielModel);
            _repository.SaveChanges();

            var logicielReadDto = _mapper.Map<LogicielReadDto>(logicielModel);
           
            return CreatedAtRoute(nameof(GetLogicielById), new { Id = logicielReadDto.IdLogiciel }, logicielReadDto);
        }


        //PUT api/Logiciels/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateLogiciel(int id, LogicielUpdateDto logicielUpdateDto)
        {
            var commandModelFromRepo = _repository.GetLogicielById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(logicielUpdateDto, commandModelFromRepo);

            _repository.UpdateLogiciel(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/Logiciels/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<LogicielUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetLogicielById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<LogicielUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateLogiciel(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/Logiciel/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteLogiciel(int id)
        {
            var commandModelFromRepo = _repository.GetLogicielById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteLogiciel(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}