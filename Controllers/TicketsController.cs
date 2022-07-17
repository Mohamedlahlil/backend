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
    [Route("api/tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepo _repository;
        private readonly IMapper _mapper;

        public TicketsController(ITicketRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/Tickets
        [HttpGet]
        public ActionResult<IEnumerable<TicketReadDto>> GetAllTickets()
        {
            var ticketItems = _repository.GetAllTickets();

            return Ok(_mapper.Map<IEnumerable<TicketReadDto>>(ticketItems));
        }


        //GET api/Tickets/{id}
        [HttpGet("{id}", Name = "GetTicketById")]
        public ActionResult<TicketReadDto> GetTicketById(int id)
        {
            var ticketItem = _repository.GetTicketById(id);
            if (ticketItem != null)
            {
                return Ok(_mapper.Map<TicketReadDto>(ticketItem));
            }
            return NotFound();
        }


        //POST api/Tickets
        [HttpPost]
        public ActionResult<TicketReadDto> CreateTicket(TicketCreateDto ticketCreateDto)
        {
            var centreModel = _mapper.Map<Ticket>(ticketCreateDto);
            _repository.CreateTicket(centreModel);
            _repository.SaveChanges();

            var ticketReadDto = _mapper.Map<TicketReadDto>(centreModel);
            // return Ok(villeModel);
            return CreatedAtRoute(nameof(GetTicketById), new { Id = ticketReadDto.IdTicket }, ticketReadDto);
        }


        //PUT api/Tickets/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTicket(int id, TicketUpdateDto ticketUpdateDto)
        {
            var commandModelFromRepo = _repository.GetTicketById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(ticketUpdateDto, commandModelFromRepo);

            _repository.UpdateTicket(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/Tickets/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<TicketUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetTicketById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<TicketUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateTicket(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/Tickets/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTicket(int id)
        {
            var commandModelFromRepo = _repository.GetTicketById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteTicket(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}