using System.Collections.Generic;
using AutoMapper;
using GPI.Data;
using GPI.Dtos;
using GPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GPI.Controllers
{
    [Route("api/Categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategorieRepo _repository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategorieRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<CategorieReadDto>> GetAllCategories()
        {
            var categorieItems = _repository.GetAllCategories();

            return Ok(_mapper.Map<IEnumerable<CategorieReadDto>>(categorieItems));
        }

        //GET api/Categories/{id}
        [HttpGet("{id}", Name = "GetCategorieById")]
        public ActionResult<CategorieReadDto> GetCategorieById(int id)
        {
            var categorieItem = _repository.GetCategorieById(id);
            if (categorieItem != null)
            {
                return Ok(_mapper.Map<CategorieReadDto>(categorieItem));
            }
            return NotFound();
        }


        //POST api/Categories
        [HttpPost]
        public ActionResult<CategorieReadDto> CreateCategorie(CategorieCreateDto categorieCreateDto)
        {
            var categorieModel = _mapper.Map<Categorie>(categorieCreateDto);
            _repository.CreateCategorie(categorieModel);
            _repository.SaveChanges();

            var categorieReadDto = _mapper.Map<CategorieReadDto>(categorieModel);
            // return Ok(villeModel);
            return CreatedAtRoute(nameof(GetCategorieById), new { Id = categorieReadDto.IdCategorie }, categorieReadDto);
        }

        //PUT api/villes/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCategorie(int id, CategorieUpdateDto categorieUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCategorieById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(categorieUpdateDto, commandModelFromRepo);

            _repository.UpdateCategorie(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/Categories/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CategorieUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCategorieById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CategorieUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateCategorie(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/Categories/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCategorie(int id)
        {
            var commandModelFromRepo = _repository.GetCategorieById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCategorie(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}