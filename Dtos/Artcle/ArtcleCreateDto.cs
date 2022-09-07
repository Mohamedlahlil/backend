using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GPI.Dtos;
using GPI.Models;

namespace GPI.Models
{
    public class ArtcleCreateDto
    {
        
        public ArticleCreateDto Article { get; set; }
        public AffArticleCreateDto AffArticle { get; set; }

    }
}