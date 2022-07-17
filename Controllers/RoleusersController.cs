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
    [Route("api/roleusers")]
    [ApiController]
    public class RoleusersController : ControllerBase
    {
        private readonly IRoleuserRepo _repository;
        private readonly IMapper _mapper;

        public RoleusersController(IRoleuserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/centres
        [HttpGet]
        public ActionResult<IEnumerable<RoleuserReadDto>> GetAllRoleusers()
        {
            var roleuserItems = _repository.GetAllRoleusers();

            return Ok(_mapper.Map<IEnumerable<RoleuserReadDto>>(roleuserItems));
        }


        //GET api/services/{id}
        [HttpGet("{id}", Name = "GetRoleuserById")]
        public ActionResult<RoleuserReadDto> GetRoleuserById(int id)
        {
            var roleuserItem = _repository.GetRoleuserById(id);
            if (roleuserItem != null)
            {
                return Ok(_mapper.Map<RoleuserReadDto>(roleuserItem));
            }
            return NotFound();
        }


        //POST api/centres
        [HttpPost]
        public ActionResult<RoleuserReadDto> CreateRoleuser(RoleuserCreateDto roleuserCreateDto)
        {
            var centreModel = _mapper.Map<Roleuser>(roleuserCreateDto);
            _repository.CreateRoleuser(centreModel);
            _repository.SaveChanges();

            var roleuserReadDto = _mapper.Map<RoleuserReadDto>(centreModel);
            // return Ok(villeModel);
            return CreatedAtRoute(nameof(GetRoleuserById), new { Id = roleuserReadDto.IdRoleuser }, roleuserReadDto);
        }


        //PUT api/Roleusers/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateRoleuser(int id, RoleuserUpdateDto roleuserUpdateDto)
        {
            var commandModelFromRepo = _repository.GetRoleuserById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(roleuserUpdateDto, commandModelFromRepo);

            _repository.UpdateRoleuser(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/Roleusers/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<RoleuserUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetRoleuserById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<RoleuserUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateRoleuser(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/Roleusers/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteRoleuser(int id)
        {
            var commandModelFromRepo = _repository.GetRoleuserById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteRoleuser(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}