using Simplr.OpenGraph.Contracts;
using Simplr.OpenGraph.Enums;
using System;
using System.Collections.Generic;

namespace Simplr.OpenGraph.Models
{
    public class OGArticle : IOGTypeInternal
    {
        public OGObjectType Type { get { return OGObjectType.Article; } }
        /// <summary>
        /// When the article was first published.
        /// </summary>
        public DateTime? PublishedTime { get; set; }
        /// <summary>
        /// When the article was last changed.
        /// </summary>
        public DateTime? ModifiedTime { get; set; }
        /// <summary>
        /// When the article is out of date after.
        /// </summary>
        public DateTime? ExpirationTime { get; set; }
        /// <summary>
        /// Writers of the article.
        /// </summary>
        public List<OGProfile> Author { get; set; }
        /// <summary>
        /// A high-level section name. E.g. Technology
        /// </summary>
        public string Section { get; set; }
        /// <summary>
        /// Tag words associated with this article.
        /// </summary>
        public List<string> Tag { get; set; }
    }
}
