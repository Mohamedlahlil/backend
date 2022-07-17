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
    [Route("api/reparations")]
    [ApiController]
    public class ReparationsController : ControllerBase
    {
        private readonly IReparationRepo _repository;
        private readonly IMapper _mapper;

        public ReparationsController(IReparationRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/Reparations
        [HttpGet]
        public ActionResult<IEnumerable<ReparationReadDto>> GetAllReparations()
        {
            var reparationItems = _repository.GetAllReparations();

            return Ok(_mapper.Map<IEnumerable<ReparationReadDto>>(reparationItems));
        }


        //GET api/Reparations/{id}
        [HttpGet("{id}", Name = "GetReparationById")]
        public ActionResult<ReparationReadDto> GetReparationById(int id)
        {
            var reparationItem = _repository.GetReparationById(id);
            if (reparationItem != null)
            {
                return Ok(_mapper.Map<ReparationReadDto>(reparationItem));
            }
            return NotFound();
        }


        //POST api/centres
        [HttpPost]
        public ActionResult<ReparationReadDto> CreateReparation(ReparationCreateDto reparationCreateDto)
        {
            var reparationModel = _mapper.Map<Reparation>(reparationCreateDto);
            _repository.CreateReparation(reparationModel);
            _repository.SaveChanges();

            var reparationReadDto = _mapper.Map<ReparationReadDto>(reparationModel);
           
            return CreatedAtRoute(nameof(GetReparationById), new { Id = reparationReadDto.IdReparation }, reparationReadDto);
        }


        //PUT api/Reparations/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateReparation(int id, ReparationUpdateDto reparationUpdateDto)
        {
            var commandModelFromRepo = _repository.GetReparationById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(reparationUpdateDto, commandModelFromRepo);

            _repository.UpdateReparation(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/Reparations/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<ReparationUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetReparationById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<ReparationUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateReparation(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/Reparations/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteReparation(int id)
        {
            var commandModelFromRepo = _repository.GetReparationById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteReparation(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}