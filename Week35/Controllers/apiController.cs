using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Week35.Attributes;

using Microsoft.AspNetCore.Authorization;
using Week35.Models;

namespace Week35.Controllers

{
    [ApiController]
    public class apiController : ControllerBase
    {
        [Route("/api/feed")]
        [HttpGet]
        public IActionResult getFeed()
        {
            return Ok("OK");            
        }

        [Route("/api/articles")]
        [HttpGet]
        public IActionResult getArticles()
        {
            return Ok("OK");
        }
        
        [Route("/api/articles")]
        [HttpPost]
        [ValidateModelState]
        [SwaggerOperation("ApiArticlesPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(Article), description: "Success")]
        public IActionResult setArticles([FromBody] Article article)
        {
            article.ArticleId = 99;
            return Ok(article);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleId"></param>
        /// <response code="200">Success</response>
        /// <response code="204">Article not found</response>
        /// <returns></returns>
        /// 

        [HttpGet]        
        [Route("/api/articles/{articleId}")]
        [ValidateModelState]
        [SwaggerOperation("ApiArticlesArticleIdGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(Article), description: "Success")]
        [SwaggerResponse(statusCode:204, description: "Article not found")]
        public IActionResult getArticleById([FromRoute] int articleId)
        { 
            if (articleId == 0) { return NoContent(); }
            return Ok(new Article() { ArticleId = articleId, ArticleImgUrl = "https://www.google.com", Author = "KTE", Body = "Lorem ipsum", Headline = "Lorem ipsum".ToUpper()});
        }

        [Route("/api/articles/{articleId}")]
        [HttpPut] 
        public IActionResult updateArticleById([FromRoute] int articleId)
        {
            return Ok(articleId);
        }

        [Route("/api/articles/{articleId}")]
        [HttpDelete]
        public IActionResult deleteArticleById([FromRoute] int articleId)
        {
            return Ok(articleId);
        }
    }
}
