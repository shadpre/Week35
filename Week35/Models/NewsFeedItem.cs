using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace Week35.Models
{
    [DataContract]
    public class NewsFeedItem
    {
        /// <summary>
        /// Gets or Sets Headline
        /// </summary>

        [DataMember(Name = "headline")]
        public string Headline { get; set; }

        /// <summary>
        /// Gets or Sets ArticleId
        /// </summary>

        [DataMember(Name = "articleId")]
        public int? ArticleId { get; set; }

        /// <summary>
        /// Gets or Sets ArticleImgUrl
        /// </summary>

        [DataMember(Name = "articleImgUrl")]
        public string ArticleImgUrl { get; set; }

        /// <summary>
        /// Gets or Sets Body
        /// </summary>

        [DataMember(Name = "body")]
        public string Body { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NewsFeedItem {\n");
            sb.Append("  Headline: ").Append(Headline).Append("\n");
            sb.Append("  ArticleId: ").Append(ArticleId).Append("\n");
            sb.Append("  ArticleImgUrl: ").Append(ArticleImgUrl).Append("\n");
            sb.Append("  Body: ").Append(Body).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
