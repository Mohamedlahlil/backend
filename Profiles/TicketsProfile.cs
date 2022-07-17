using AutoMapper;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Profiles
{
    public class TicketsProfile : Profile
    {
        public TicketsProfile()
        {
            //Source-->Target
            CreateMap<Ticket, TicketReadDto>();
            CreateMap<TicketCreateDto, Ticket>();
            CreateMap<TicketUpdateDto, Ticket>();
            CreateMap<Ticket, TicketUpdateDto>();
        }
    }
}