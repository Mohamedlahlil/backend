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
    [Route("api/centres")]
    [ApiController]
    public class CentresController : ControllerBase
    {
        private readonly ICentreRepo _repository;
        private readonly IMapper _mapper;

        public CentresController(ICentreRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/centres
        [HttpGet]
        public ActionResult<IEnumerable<CentreReadDto>> GetAllCentres()
        {
            var centreItems = _repository.GetAllCentres();

            return Ok(_mapper.Map<IEnumerable<CentreReadDto>>(centreItems));
        }


        //GET api/centres/{id}
        [HttpGet("{id}", Name = "GetCentreById")]
        public ActionResult<CentreReadDto> GetCentreById(int id)
        {
            var centreItem = _repository.GetCentreById(id);
            if (centreItem != null)
            {
                return Ok(_mapper.Map<CentreReadDto>(centreItem));
            }
            return NotFound();
        }


        //POST api/centres
        [HttpPost]
        public ActionResult<CentreReadDto> CreateCentre(CentreCreateDto centreCreateDto)
        {
            var centreModel = _mapper.Map<Centre>(centreCreateDto);
            _repository.CreateCentre(centreModel);
            _repository.SaveChanges();

            var centreReadDto = _mapper.Map<CentreReadDto>(centreModel);
            // return Ok(villeModel);
            return CreatedAtRoute(nameof(GetCentreById), new { Id = centreReadDto.IdCentre }, centreReadDto);
        }


        //PUT api/centres/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCentre(int id, CentreUpdateDto centreUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCentreById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(centreUpdateDto, commandModelFromRepo);

            _repository.UpdateCentre(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/centres/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CentreUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCentreById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CentreUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateCentre(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/centres/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCentre(int id)
        {
            var commandModelFromRepo = _repository.GetCentreById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCentre(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}