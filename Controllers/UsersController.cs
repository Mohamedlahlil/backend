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
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/centres
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
            var userItems = _repository.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
        }


        //GET api/centres/{id}
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserReadDto> GetUserById(int id)
        {
            var userItem = _repository.GetUserById(id);
            if (userItem != null)
            {
                return Ok(_mapper.Map<UserReadDto>(userItem));
            }
            return NotFound();
        }


        //POST api/centres
        [HttpPost]
        public ActionResult<UserReadDto> CreateUser(UserCreateDto userCreateDto)
        {
            var centreModel = _mapper.Map<User>(userCreateDto);
            _repository.CreateUser(centreModel);
            _repository.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(centreModel);
            // return Ok(villeModel);
            return CreatedAtRoute(nameof(GetUserById), new { Id = userReadDto.IdUser }, userReadDto);
        }


        //PUT api/centres/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            var commandModelFromRepo = _repository.GetUserById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(userUpdateDto, commandModelFromRepo);

            _repository.UpdateUser(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/Users/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<UserUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetUserById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<UserUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateUser(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/users/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var commandModelFromRepo = _repository.GetUserById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteUser(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}