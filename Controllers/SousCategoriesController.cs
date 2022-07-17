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
    [Route("api/souscategories")]
    [ApiController]
    public class SousCategoriesController : ControllerBase
    {
        private readonly ISousCategorieRepo _repository;
        private readonly IMapper _mapper;

        public SousCategoriesController(ISousCategorieRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/souscategories
        [HttpGet]
        public ActionResult<IEnumerable<SousCategorieReadDto>> GetAllSousCategories()
        {
            var souscatItems = _repository.GetAllSousCategories();

            return Ok(_mapper.Map<IEnumerable<SousCategorieReadDto>>(souscatItems));
        }


        //GET api/souscategories/{id}
        [HttpGet("{id}", Name = "GetSousCategorieById")]
        public ActionResult<SousCategorieReadDto> GetSousCategorieById(int id)
        {
            var souscatItem = _repository.GetSousCategorieById(id);
            if (souscatItem != null)
            {
                return Ok(_mapper.Map<SousCategorieReadDto>(souscatItem));
            }
            return NotFound();
        }


        //POST api/souscategories
        [HttpPost]
        public ActionResult<SousCategorieReadDto> CreateSousCategorie(SousCategorieCreateDto souscategorieCreateDto)
        {
            var souscategorieModel = _mapper.Map<SousCategorie>(souscategorieCreateDto);
            _repository.CreateSousCategorie(souscategorieModel);
            _repository.SaveChanges();

            var souscategorieReadDto = _mapper.Map<SousCategorieReadDto>(souscategorieModel);
            // return Ok(villeModel);
            return CreatedAtRoute(nameof(GetSousCategorieById), new { Id = souscategorieReadDto.IdSousCat }, souscategorieReadDto);
        }


        //PUT api/souscategories/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSousCategorie(int id, SousCategorieUpdateDto souscategorieUpdateDto)
        {
            var commandModelFromRepo = _repository.GetSousCategorieById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(souscategorieUpdateDto, commandModelFromRepo);

            _repository.UpdateSousCategorie(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/souscategories/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<SousCategorieUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetSousCategorieById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<SousCategorieUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateSousCategorie(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/souscategories/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteSousCategorie(int id)
        {
            var commandModelFromRepo = _repository.GetSousCategorieById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteSousCategorie(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}