using System.Collections.Generic;
using AutoMapper;
using GPI.Data;
using GPI.Dtos;
using GPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GPI.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepo _repository;
        private readonly IMapper _mapper;

        public RolesController(IRoleRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/roles
        [HttpGet]
        public ActionResult<IEnumerable<RoleReadDto>> GetAllRoles()
        {
            var roleItems = _repository.GetAllRoles();

            return Ok(_mapper.Map<IEnumerable<RoleReadDto>>(roleItems));
        }

        //GET api/roles/{id}
        [HttpGet("{id}", Name = "GetRoleById")]
        public ActionResult<RoleReadDto> GetRoleById(int id)
        {
            var categorieItem = _repository.GetRoleById(id);
            if (categorieItem != null)
            {
                return Ok(_mapper.Map<RoleReadDto>(categorieItem));
            }
            return NotFound();
        }


        //POST api/Categories
        [HttpPost]
        public ActionResult<RoleReadDto> CreateRole(RoleCreateDto roleCreateDto)
        {
            var categorieModel = _mapper.Map<Role>(roleCreateDto);
            _repository.CreateRole(categorieModel);
            _repository.SaveChanges();

            var roleReadDto = _mapper.Map<RoleReadDto>(categorieModel);
            // return Ok(villeModel);
            return CreatedAtRoute(nameof(GetRoleById), new { Id = roleReadDto.IdRole }, roleReadDto);
        }

        //PUT api/roles/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateRole(int id, RoleUpdateDto roleUpdateDto)
        {
            var commandModelFromRepo = _repository.GetRoleById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(roleUpdateDto, commandModelFromRepo);

            _repository.UpdateRole(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/roles/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<RoleUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetRoleById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<RoleUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateRole(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/Categories/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteRole(int id)
        {
            var commandModelFromRepo = _repository.GetRoleById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteRole(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}