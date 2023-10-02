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
using Dapper;
using Npgsql;

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
            List<NewsFeedItem> items = new List<NewsFeedItem>();
            using (NpgsqlConnection con = new NpgsqlConnection(DatabaseConnector.GetInstance().ConnectionString))
            {
                string query = "select headline, articleId, articleImgUrl, body from news.articles";
                items = con.Query<NewsFeedItem>(query).ToList();
            }
            foreach (NewsFeedItem item in items)
            {
                if (item.Body.Length> 50)
                {
                    item.Body = item.Body.Substring(0, 50);
                }
            }
            return Ok(items);
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
            List<SearchArticleItem> items = new List<SearchArticleItem>();
            using (NpgsqlConnection con = new NpgsqlConnection(DatabaseConnector.GetInstance().ConnectionString))
            {
                string query = "select articleid, headline, author from news.articles WHERE headline LIKE LOWER(@searchTerm) OR body LIKE LOWER(@searchTerm) LIMIT @pageSize;";
                items = con.Query<SearchArticleItem>(query, new { searchTerm = '%' + searchTerm + '%', pageSize }).ToList();
            }
            
            return Ok(items);
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
            Article result = new Article();
            if (body.Headline.Length < 5 || body.Headline.Length > 30) return BadRequest("Headline must be between 5 and 30 chars");
            if (body.Body.Length > 1000) return BadRequest("Body must be max 1000 chars");
            List<string> authors = new List<string>()
            {
                "Bob", "Rob", "Dob", "Lob"
            };
            if (!authors.Contains(body.Author)) return BadRequest("Wrong author");
            using (NpgsqlConnection con = new NpgsqlConnection(DatabaseConnector.GetInstance().ConnectionString))
            {
                string query = $@"
                INSERT INTO news.articles (headline, body, author, articleimgurl) 
                VALUES (@headline, @body, @author, @articleImgUrl)
                RETURNING articles.articleid as {nameof(Article.ArticleId)},
                body as {nameof(Article.Body)},
                headline as {nameof(Article.Headline)},
                author as {nameof(Article.Author)},
                articleimgurl as {nameof(Article.ArticleImgUrl)}; ";
                result = con.QueryFirst<Article>(query, new { body.Headline, body.Author, body.ArticleImgUrl, body.Body });
            }

            return Ok(result);
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
        [SwaggerResponse(statusCode: 204, description: "Article not found")]
        public IActionResult getArticleById([FromRoute] int articleId)
        {
            Article result = new Article();
            using (NpgsqlConnection con = new NpgsqlConnection(DatabaseConnector.GetInstance().ConnectionString))
            {
                string query = $@"SELECT articleid as {nameof(Article.ArticleId)},
                                body as {nameof(Article.Body)},
                                headline as {nameof(Article.Headline)},
                                author as {nameof(Article.Author)},
                                articleimgurl as {nameof(Article.ArticleImgUrl)} 
                                FROM news.articles WHERE articleid = @articleId;";
                result = con.QueryFirst<Article>(query, new { articleId });
            }
            return Ok(result);
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
            Article result = new Article();
            
            if (body.Headline.Length < 5 || body.Headline.Length > 30) return BadRequest("Headline must be between 5 and 30 chars");
            if (body.Body.Length > 1000) return BadRequest("Body must be max 1000 chars");
            List<string> authors = new List<string>()
            {
                "Bob", "Rob", "Dob", "Lob"
            };
            if (!authors.Contains(body.Author)) return BadRequest("Wrong author");
            using (NpgsqlConnection con = new NpgsqlConnection(DatabaseConnector.GetInstance().ConnectionString))
            {
                string query = $@"
UPDATE news.articles SET body = @body, headline = @headline, articleimgurl = @articleImgUrl, author = @author
WHERE articleid = @articleId
RETURNING articleid as {nameof(Article.ArticleId)},
    body as {nameof(Article.Body)},
       headline as {nameof(Article.Headline)},
        author as {nameof(Article.Author)},
        articleimgurl as {nameof(Article.ArticleImgUrl)};
            ";
                result = con.QueryFirst<Article>(query, new { body.Headline, articleId, body.Body, body.ArticleImgUrl, body.Author });
            }
            return Ok(result);
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
            bool result = false;
            using (NpgsqlConnection con = new NpgsqlConnection(DatabaseConnector.GetInstance().ConnectionString))
            {
                string query = "DELETE FROM news.articles WHERE articleid = @articleId;";
                result = con.Execute(query, new { articleId }) == 1;
            }
            return Ok(result);
        }
    }
}
