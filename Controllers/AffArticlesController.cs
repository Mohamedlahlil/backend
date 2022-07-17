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
    [Route("api/affarticles")]
    [ApiController]
    public class AffArticlesController : ControllerBase
    {
        private readonly IAffArticleRepo _repository;
        private readonly IMapper _mapper;

        public AffArticlesController(IAffArticleRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/Afftelephonie
        [HttpGet]
        public ActionResult<IEnumerable<AffArticleReadDto>> GetAllAffArticles()
        {
            var affArticleItems = _repository.GetAllAffArticles();

            return Ok(_mapper.Map<IEnumerable<AffArticleReadDto>>(affArticleItems));
        }


        //GET api/AffTelephonie/{id}
        [HttpGet("{id}", Name = "GetAffArticleById")]
        public ActionResult<AffArticleReadDto> GetAffArticleById(int id)
        {
            var affArticleItem = _repository.GetAffArticleById(id);
            if (affArticleItem != null)
            {
                return Ok(_mapper.Map<AffArticleReadDto>(affArticleItem));
            }
            return NotFound();
        }


        //POST api/AffArticle
        [HttpPost]
        public ActionResult<AffArticleReadDto> CreateAffArticle(AffArticleCreateDto affArticleCreateDto)
        {
            var centreModel = _mapper.Map<AffArticle>(affArticleCreateDto);
            _repository.CreateAffArticle(centreModel);
            _repository.SaveChanges();

            var affArticleReadDto = _mapper.Map<AffArticleReadDto>(centreModel);
            // return Ok(villeModel);
            return CreatedAtRoute(nameof(GetAffArticleById), new { Id = affArticleReadDto.IdAffArticle }, affArticleReadDto);
        }


        //PUT api/Telephonie/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, AffArticleUpdateDto affArticleUpdateDto)
        {
            var commandModelFromRepo = _repository.GetAffArticleById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(affArticleUpdateDto, commandModelFromRepo);

            _repository.UpdateAffArticle(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/AffArticle/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<AffArticleUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetAffArticleById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<AffArticleUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateAffArticle(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/AffArticle/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteAffArticle(int id)
        {
            var commandModelFromRepo = _repository.GetAffArticleById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteAffArticle(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}