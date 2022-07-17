using System.Collections.Generic;
using AutoMapper;
using GPI.Data;
using GPI.Dtos;
using GPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GPI.Controllers
{
    [Route("api/types")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly ITypeRepo _repository;
        private readonly IMapper _mapper;

        public TypesController(ITypeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/types
        [HttpGet]
        public ActionResult<IEnumerable<TypeReadDto>> GetAllTypes()
        {
            var typeItems = _repository.GetAllTypes();

            return Ok(_mapper.Map<IEnumerable<TypeReadDto>>(typeItems));
        }

        //GET api/types/{id}
        [HttpGet("{id}", Name = "GetTypeById")]
        public ActionResult<TypeReadDto> GetTypeById(int id)
        {
            var typeItem = _repository.GetTypeById(id);
            if (typeItem != null)
            {
                return Ok(_mapper.Map<TypeReadDto>(typeItem));
            }
            return NotFound();
        }


        //POST api/types
        [HttpPost]
        public ActionResult<TypeReadDto> CreateType(TypeCreateDto typeCreateDto)
        {
            var typeModel = _mapper.Map<Type>(typeCreateDto);
            _repository.CreateType(typeModel);
            _repository.SaveChanges();

            var typeReadDto = _mapper.Map<TypeReadDto>(typeModel);
           
            return CreatedAtRoute(nameof(GetTypeById), new { Id = typeReadDto.IdType }, typeReadDto);
        }

        //PUT api/types/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateType(int id, TypeUpdateDto typeUpdateDto)
        {
            var commandModelFromRepo = _repository.GetTypeById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(typeUpdateDto, commandModelFromRepo);

            _repository.UpdateType(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/types/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<TypeUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetTypeById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<TypeUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateType(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/types/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteType(int id)
        {
            var commandModelFromRepo = _repository.GetTypeById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteType(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}