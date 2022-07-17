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
    [Route("api/services")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepo _repository;
        private readonly IMapper _mapper;

        public ServicesController(IServiceRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/centres
        [HttpGet]
        public ActionResult<IEnumerable<ServiceReadDto>> GetAllServices()
        {
            var serviceItems = _repository.GetAllServices();

            return Ok(_mapper.Map<IEnumerable<ServiceReadDto>>(serviceItems));
        }


        //GET api/services/{id}
        [HttpGet("{id}", Name = "GetServiceById")]
        public ActionResult<ServiceReadDto> GetServiceById(int id)
        {
            var serviceItem = _repository.GetServiceById(id);
            if (serviceItem != null)
            {
                return Ok(_mapper.Map<ServiceReadDto>(serviceItem));
            }
            return NotFound();
        }


        //POST api/centres
        [HttpPost]
        public ActionResult<ServiceReadDto> CreateService(ServiceCreateDto serviceCreateDto)
        {
            var centreModel = _mapper.Map<Service>(serviceCreateDto);
            _repository.CreateService(centreModel);
            _repository.SaveChanges();

            var serviceReadDto = _mapper.Map<ServiceReadDto>(centreModel);
            // return Ok(villeModel);
            return CreatedAtRoute(nameof(GetServiceById), new { Id = serviceReadDto.IdService }, serviceReadDto);
        }


        //PUT api/services/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateService(int id, ServiceUpdateDto serviceUpdateDto)
        {
            var commandModelFromRepo = _repository.GetServiceById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(serviceUpdateDto, commandModelFromRepo);

            _repository.UpdateService(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/services/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<ServiceUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetServiceById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<ServiceUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateService(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/services/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteService(int id)
        {
            var commandModelFromRepo = _repository.GetServiceById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteService(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}