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
    [Route("api/afflogiciels")]
    [ApiController]
    public class AffLogicielsController : ControllerBase
    {
        private readonly IAffLogicielRepo _repository;
        private readonly IMapper _mapper;

        public AffLogicielsController(IAffLogicielRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/AffLogiciels
        [HttpGet]
        public ActionResult<IEnumerable<AffLogicielReadDto>> GetAllAffLogiciels()
        {
            var afflogicielItems = _repository.GetAllAffLogiciels();

            return Ok(_mapper.Map<IEnumerable<AffLogicielReadDto>>(afflogicielItems));
        }


        //GET api/AffLogiciel/{id}
        [HttpGet("{id}", Name = "GetAffLogicielById")]
        public ActionResult<AffLogicielReadDto> GetAffLogicielById(int id)
        {
            var affLogicielItem = _repository.GetAffLogicielById(id);
            if (affLogicielItem != null)
            {
                return Ok(_mapper.Map<AffLogicielReadDto>(affLogicielItem));
            }
            return NotFound();
        }


        //POST api/AffLogiciel
        [HttpPost]
        public ActionResult<AffLogicielReadDto> CreateAffLogiciel(AffLogicielCreateDto affLogicielCreateDto)
        {
            var centreModel = _mapper.Map<AffLogiciel>(affLogicielCreateDto);
            _repository.CreateAffLogiciel(centreModel);
            _repository.SaveChanges();

            var affLogicielReadDto = _mapper.Map<AffLogicielReadDto>(centreModel);
            // return Ok(villeModel);
            return CreatedAtRoute(nameof(GetAffLogicielById), new { Id = affLogicielReadDto.IdAffLogiciel }, affLogicielReadDto);
        }


        //PUT api/AffLogiciel/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, AffLogicielUpdateDto affLogicielUpdateDto)
        {
            var commandModelFromRepo = _repository.GetAffLogicielById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(affLogicielUpdateDto, commandModelFromRepo);

            _repository.UpdateAffLogiciel(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/AffLogiciel/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<AffLogicielUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetAffLogicielById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<AffLogicielUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateAffLogiciel(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/AffLogiciel/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteAffLogiciel(int id)
        {
            var commandModelFromRepo = _repository.GetAffLogicielById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteAffLogiciel(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}