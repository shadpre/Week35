using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace Week35.Models
{
    [DataContract]
    public partial class SearchArticleItem
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
        /// Gets or Sets Author
        /// </summary>

        [DataMember(Name = "author")]
        public string Author { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SearchArticleItem {\n");
            sb.Append("  Headline: ").Append(Headline).Append("\n");
            sb.Append("  ArticleId: ").Append(ArticleId).Append("\n");
            sb.Append("  Author: ").Append(Author).Append("\n");
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
