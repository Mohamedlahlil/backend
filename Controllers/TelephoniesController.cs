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
    [Route("api/telephonies")]
    [ApiController]
    public class TelephoniesController : ControllerBase
    {
        private readonly ITelephonieRepo _repository;
        private readonly IMapper _mapper;

        public TelephoniesController(ITelephonieRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/Telephonies
        [HttpGet]
        public ActionResult<IEnumerable<TelephonieReadDto>> GetAllTelephonies()
        {
            var telephonieItems = _repository.GetAllTelephonies();

            return Ok(_mapper.Map<IEnumerable<TelephonieReadDto>>(telephonieItems));
        }


        //GET api/Telephonies/{id}
        [HttpGet("{id}", Name = "GetTelephonieById")]
        public ActionResult<TelephonieReadDto> GetTelephonieById(int id)
        {
            var telephonieItem = _repository.GetTelephonieById(id);
            if (telephonieItem != null)
            {
                return Ok(_mapper.Map<TelephonieReadDto>(telephonieItem));
            }
            return NotFound();
        }


        //POST api/Telephonies
        [HttpPost]
        public ActionResult<TelephonieReadDto> CreateTelephonie(TelephonieCreateDto telephonieCreateDto)
        {
            var telephonieModel = _mapper.Map<Telephonie>(telephonieCreateDto);
            _repository.CreateTelephonie(telephonieModel);
            _repository.SaveChanges();

            var telephonieReadDto = _mapper.Map<TelephonieReadDto>(telephonieModel);
           
            return CreatedAtRoute(nameof(GetTelephonieById), new { Id = telephonieReadDto.IdTelephonie }, telephonieReadDto);
        }


        //PUT api/Telephonie/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTelephonie(int id, TelephonieUpdateDto telephonieUpdateDto)
        {
            var commandModelFromRepo = _repository.GetTelephonieById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(telephonieUpdateDto, commandModelFromRepo);

            _repository.UpdateTelephonie(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/Telephonies/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<TelephonieUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetTelephonieById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<TelephonieUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateTelephonie(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/Telephonie/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTelephonie(int id)
        {
            var commandModelFromRepo = _repository.GetTelephonieById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteTelephonie(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}