using System.Collections.Generic;
using AutoMapper;
using GPI.Data;
using GPI.Dtos;
using GPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GPI.Controllers
{
    [Route("api/fournisseurs")]
    [ApiController]
    public class FournisseursController : ControllerBase
    {
        private readonly IFournisseurRepo _repository;
        private readonly IMapper _mapper;

        public FournisseursController(IFournisseurRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/fournisseurs
        [HttpGet]
        public ActionResult<IEnumerable<FournisseurReadDto>> GetAllFournisseurs()
        {
            var fournisseurItems = _repository.GetAllFournisseurs();

            return Ok(_mapper.Map<IEnumerable<FournisseurReadDto>>(fournisseurItems));
        }

        //GET api/fournisseurs/{id}
        [HttpGet("{id}", Name = "GetFournisseurById")]
        public ActionResult<FournisseurReadDto> GetFournisseurById(int id)
        {
            var commandItem = _repository.GetFournisseurById(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<FournisseurReadDto>(commandItem));
            }
            return NotFound();
        }


        //POST api/Fournisseurs
        [HttpPost]
        public ActionResult<FournisseurReadDto> CreateFournisseur(FournisseurCreateDto fournisseurCreateDto)
        {
            var fournisseurModel = _mapper.Map<Fournisseur>(fournisseurCreateDto);
            _repository.CreateFournisseur(fournisseurModel);
            _repository.SaveChanges();

            var fournisseurReadDto = _mapper.Map<FournisseurReadDto>(fournisseurModel);
            // return Ok(commandModel);
            return CreatedAtRoute(nameof(GetFournisseurById), new { Id = fournisseurReadDto.IdFournisseur }, fournisseurReadDto);
        }

        //PUT api/Fournisseurs/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateFournisseur(int id, FournisseurUpdateDto fournisseurUpdateDto)
        {
            var commandModelFromRepo = _repository.GetFournisseurById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(fournisseurUpdateDto, commandModelFromRepo);

            _repository.UpdateFournisseur(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<FournisseurUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetFournisseurById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<FournisseurUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateFournisseur(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/Fournisseurs/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteFournisseur(int id)
        {
            var commandModelFromRepo = _repository.GetFournisseurById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteFournisseur(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}