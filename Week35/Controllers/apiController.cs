using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Week35.Models;
using static Week35.Models.CreateArticleRequestsDto;

namespace Week35.Controllers

{
    [ApiController]
    public class apiController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/feed")]
        [SwaggerOperation("ApiFeedGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<NewsFeedItem>), description: "Success")]
        public IActionResult getFeed()
        {
            throw new NotImplementedException();        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="pageSize"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/articles")]        
        [SwaggerOperation("ApiArticlesGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<SearchArticleItem>), description: "Success")]
        public IActionResult getArticles([FromQuery][MinLength(3)] string searchTerm, [FromQuery][Range(1, 2147483647)] int? pageSize)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/articles")]
        [SwaggerOperation("ApiArticlesPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(Article), description: "Success")]
        public IActionResult setArticles([FromBody] CreateArticleRequestDto body)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleId"></param>
        /// <response code="200">Success</response>
        /// <response code="204">Article not found</response>
        /// <returns>Article with requested articleId</returns>
        /// 
        [HttpGet]        
        [Route("/api/articles/{articleId}")]        
        [SwaggerOperation("ApiArticlesArticleIdGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(Article), description: "Success")]
        [SwaggerResponse(statusCode:204, description: "Article not found")]
        public IActionResult getArticleById([FromRoute] int articleId)
        { 
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="body"></param>
        /// <response code="200">Success</response>
        [HttpPut]
        [Route("/api/articles/{articleId}")]
        [SwaggerOperation("ApiArticlesArticleIdPut")]
        [SwaggerResponse(statusCode: 200, type: typeof(Article), description: "Success")]
        public IActionResult updateArticleById([FromRoute][Required] int? articleId, [FromBody] UpdateArticleRequestDto body)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleId"></param>
        /// <response code="200">Success</response>
        [HttpDelete]
        [Route("/api/articles/{articleId}")]
        [SwaggerOperation("ApiArticlesArticleIdDelete")]
        public IActionResult deleteArticleById([FromRoute][Required] int? articleId)
        {
            throw new NotImplementedException();
        }
    }
}
