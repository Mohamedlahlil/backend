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
    [Route("api/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepo _repository;
        private readonly IMapper _mapper;

        public ArticlesController(IArticleRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET  api/Articles
        [HttpGet]
        public ActionResult<IEnumerable<ArticleReadDto>> GetAllArticles()
        {
            var articleItems = _repository.GetAllArticles();

            return Ok(_mapper.Map<IEnumerable<ArticleReadDto>>(articleItems));
        }


        //GET api/Articles/{id}
        [HttpGet("{id}", Name = "GetArticleById")]
        public ActionResult<ArticleReadDto> GetArticleById(int id)
        {
            var articleItem = _repository.GetArticleById(id);
            if (articleItem != null)
            {
                return Ok(_mapper.Map<ArticleReadDto>(articleItem));
            }
            return NotFound();
        }


        //POST api/Articles
        [HttpPost]
        public ActionResult<ArticleReadDto> CreateArticle(ArtcleCreateDto articleCreateDto)
        {
            var articleModel = _mapper.Map<Article>(articleCreateDto);
            _repository.CreateArticle(articleModel);
            _repository.SaveChanges();

            var articleReadDto = _mapper.Map<ArticleReadDto>(articleModel);
            // return Ok(villeModel);
            return CreatedAtRoute(nameof(GetArticleById), new { Id = articleReadDto.IdArticle }, articleReadDto);
        }


        //PUT api/Articles/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateArticle(int id, ArticleUpdateDto articleUpdateDto)
        {
            var commandModelFromRepo = _repository.GetArticleById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(articleUpdateDto, commandModelFromRepo);

            _repository.UpdateArticle(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //PATCH api/Articles/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<ArticleUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetArticleById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<ArticleUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateArticle(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/Articles/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteArticle(int id)
        {
            var commandModelFromRepo = _repository.GetArticleById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteArticle(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}