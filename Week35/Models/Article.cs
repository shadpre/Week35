using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Week35.Models
{
    [DataContract]
    public class Article
    {
        [DataMember(Name = "headline")]
        public string? Headline { get; set; }
        [DataMember(Name = "body")]
        public string? Body { get; set; }
        [DataMember(Name = "articleId")]
        public int ArticleId { get; set; }
        [DataMember(Name = "articleImgUrl")]
        public string? ArticleImgUrl { get; set; }
        [DataMember(Name = "author")]
        public string? Author { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Article {\n");
            sb.Append("  Headline: ").Append(Headline).Append("\n");
            sb.Append("  Body: ").Append(Body).Append("\n");
            sb.Append("  ArticleId: ").Append(ArticleId).Append("\n");
            sb.Append("  ArticleImgUrl: ").Append(ArticleImgUrl).Append("\n");
            sb.Append("  Author: ").Append(Author).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
