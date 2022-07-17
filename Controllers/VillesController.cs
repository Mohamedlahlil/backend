using System.Collections.Generic;
using AutoMapper;
using GPI.Data;
using GPI.Dtos;
using GPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GPI.Controllers
{
    [Route("api/villes")]
    [ApiController]
    public class VillesController : ControllerBase
    {
        private readonly IVilleRepo _repository;
        private readonly IMapper _mapper;

        public VillesController(IVilleRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/villes
        [HttpGet]
        public ActionResult<IEnumerable<VilleReadDto>> GetAllvilles()
        {
            var villeItems = _repository.GetAllVilles();

            return Ok(_mapper.Map<IEnumerable<VilleReadDto>>(villeItems));
        }

        //GET api/villes/{id}
        [HttpGet("{id}", Name = "GetvilleById")]
        public ActionResult<VilleReadDto> GetVilleById(int id)
        {
            var villeItem = _repository.GetVilleById(id);
            if (villeItem != null)
            {
                return Ok(_mapper.Map<VilleReadDto>(villeItem));
            }
            return NotFound();
        }


        //POST api/villes
        [HttpPost]
        public ActionResult<VilleReadDto> CreateVille(VilleCreateDto villeCreateDto)
        {
            var villeModel = _mapper.Map<Ville>(villeCreateDto);
            _repository.CreateVille(villeModel);
            _repository.SaveChanges();

            var villeReadDto = _mapper.Map<VilleReadDto>(villeModel);
            // return Ok(villeModel);
            return CreatedAtRoute(nameof(GetVilleById), new { Id = villeReadDto.Id }, villeReadDto);
        }

        //PUT api/villes/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateVille(int id, VilleUpdateDto villeUpdateDto)
        {
            var commandModelFromRepo = _repository.GetVilleById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(villeUpdateDto, commandModelFromRepo);

            _repository.UpdateVille(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/villes/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<VilleUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetVilleById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<VilleUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateVille(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/villes/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteVille(int id)
        {
            var commandModelFromRepo = _repository.GetVilleById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteVille(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}