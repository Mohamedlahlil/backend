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
    [Route("api/pauses")]
    [ApiController]
    public class PausessController : ControllerBase
    {
        private readonly IPausesRepo _repository;
        private readonly IMapper _mapper;

        public PausessController(IPausesRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/Pausess
        [HttpGet]
        public ActionResult<IEnumerable<PausesReadDto>> GetAllPausess()
        {
            var pausesItems = _repository.GetAllPausess();

            return Ok(_mapper.Map<IEnumerable<PausesReadDto>>(pausesItems));
        }


        //GET api/Pausess/{id}
        [HttpGet("{id}", Name = "GetPausesById")]
        public ActionResult<PausesReadDto> GetPausesById(int id)
        {
            var pausesItem = _repository.GetPausesById(id);
            if (pausesItem != null)
            {
                return Ok(_mapper.Map<PausesReadDto>(pausesItem));
            }
            return NotFound();
        }


        //POST api/Pausess
        [HttpPost]
        public ActionResult<PausesReadDto> CreatePauses(PausesCreateDto pausesCreateDto)
        {
            var pausesModel = _mapper.Map<Pauses>(pausesCreateDto);
            _repository.CreatePauses(pausesModel);
            _repository.SaveChanges();

            var pausesReadDto = _mapper.Map<PausesReadDto>(pausesModel);
           
            return CreatedAtRoute(nameof(GetPausesById), new { Id = pausesReadDto.IdPauses }, pausesReadDto);
        }


        //PUT api/Pausess/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePauses(int id, PausesUpdateDto pausesUpdateDto)
        {
            var commandModelFromRepo = _repository.GetPausesById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(pausesUpdateDto, commandModelFromRepo);

            _repository.UpdatePauses(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/Pausess/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<PausesUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetPausesById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<PausesUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdatePauses(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/Pausess/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePauses(int id)
        {
            var commandModelFromRepo = _repository.GetPausesById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeletePauses(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}