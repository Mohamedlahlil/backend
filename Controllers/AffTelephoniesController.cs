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
    [Route("api/afftelephonies")]
    [ApiController]
    public class AffTelephoniesController : ControllerBase
    {
        private readonly IAffTelephonieRepo _repository;
        private readonly IMapper _mapper;

        public AffTelephoniesController(IAffTelephonieRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/Afftelephonie
        [HttpGet]
        public ActionResult<IEnumerable<AffTelephonieReadDto>> GetAllAffTelephonies()
        {
            var affTelephonieItems = _repository.GetAllAffTelephonies();

            return Ok(_mapper.Map<IEnumerable<AffTelephonieReadDto>>(affTelephonieItems));
        }


        //GET api/AffTelephonie/{id}
        [HttpGet("{id}", Name = "GetAffTelephonieById")]
        public ActionResult<AffTelephonieReadDto> GetAffTelephonieById(int id)
        {
            var affTelephonieItem = _repository.GetAffTelephonieById(id);
            if (affTelephonieItem != null)
            {
                return Ok(_mapper.Map<AffTelephonieReadDto>(affTelephonieItem));
            }
            return NotFound();
        }


        //POST api/AffTelephonie
        [HttpPost]
        public ActionResult<AffTelephonieReadDto> CreateAffTelephonie(AffTelephonieCreateDto affTelephonieCreateDto)
        {
            var centreModel = _mapper.Map<AffTelephonie>(affTelephonieCreateDto);
            _repository.CreateAffTelephonie(centreModel);
            _repository.SaveChanges();

            var affTelephonieReadDto = _mapper.Map<AffTelephonieReadDto>(centreModel);
            // return Ok(villeModel);
            return CreatedAtRoute(nameof(GetAffTelephonieById), new { Id = affTelephonieReadDto.IdAffTelephonie }, affTelephonieReadDto);
        }


        //PUT api/Telephonie/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, AffTelephonieUpdateDto affTelephonieUpdateDto)
        {
            var commandModelFromRepo = _repository.GetAffTelephonieById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(affTelephonieUpdateDto, commandModelFromRepo);

            _repository.UpdateAffTelephonie(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/AffTelephonie/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<AffTelephonieUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetAffTelephonieById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<AffTelephonieUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateAffTelephonie(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/AffTelephonie/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteAffTelephonie(int id)
        {
            var commandModelFromRepo = _repository.GetAffTelephonieById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteAffTelephonie(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}