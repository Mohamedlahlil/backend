using System.Collections.Generic;
using AutoMapper;
using GPI.Data;
using GPI.Dtos;
using GPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GPI.Controllers
{
    [Route("api/typeCategories")]
    [ApiController]
    public class TypeCategoriesController : ControllerBase
    {
        private readonly ITypeCategorieRepo _repository;
        private readonly IMapper _mapper;

        public TypeCategoriesController(ITypeCategorieRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/typeCategories
        [HttpGet]
        public ActionResult<IEnumerable<TypeCategorieReadDto>> GetAllTypeCategories()
        {
            var typecategorieItems = _repository.GetAllTypeCategories();

            return Ok(_mapper.Map<IEnumerable<TypeCategorieReadDto>>(typecategorieItems));
        }

        //GET api/typeCategories/{id}
        [HttpGet("{id}", Name = "GetTypeCategorieById")]
        public ActionResult<TypeCategorieReadDto> GetTypeCategorieById(int id)
        {
            var typecategorieItem = _repository.GetTypeCategorieById(id);
            if (typecategorieItem != null)
            {
                return Ok(_mapper.Map<TypeCategorieReadDto>(typecategorieItem));
            }
            return NotFound();
        }


        //POST api/typeCategories
        [HttpPost]
        public ActionResult<TypeCategorieReadDto> CreateTypeCategorie(TypeCategorieCreateDto typecategorieCreateDto)
        {
            var typecategorieModel = _mapper.Map<TypeCategorie>(typecategorieCreateDto);
            _repository.CreateTypeCategorie(typecategorieModel);
            _repository.SaveChanges();

            var typecategorieReadDto = _mapper.Map<TypeCategorieReadDto>(typecategorieModel);
            // return Ok(villeModel);
            return CreatedAtRoute(nameof(GetTypeCategorieById), new { Id = typecategorieReadDto.IdTypeCategorie }, typecategorieReadDto);
        }

        //PUT api/typeCategorie/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTypeCategorie(int id, TypeCategorieUpdateDto typecategorieUpdateDto)
        {
            var commandModelFromRepo = _repository.GetTypeCategorieById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(typecategorieUpdateDto, commandModelFromRepo);

            _repository.UpdateTypeCategorie(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/TypeCategories/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<TypeCategorieUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetTypeCategorieById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<TypeCategorieUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateTypeCategorie(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/TypeCategories/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTypeCategorie(int id)
        {
            var commandModelFromRepo = _repository.GetTypeCategorieById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteTypeCategorie(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}