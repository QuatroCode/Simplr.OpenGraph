using Simplr.OpenGraph.Contracts;
using Simplr.OpenGraph.Enums;
using System;
using System.Collections.Generic;

namespace Simplr.OpenGraph.Models
{
    public class OGBook : IOGTypeInternal
    {
        public OGObjectType Type { get { return OGObjectType.Book; } }
        /// <summary>
        /// Who wrote this book.
        /// </summary>
        public List<OGProfile> Author { get; set; }
        /// <summary>
        /// The ISBN (International Standard Book Number)
        /// </summary>
        public string Isbn { get; set; }
        /// <summary>
        /// The date the book was released.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }
        /// <summary>
        /// Tag words associated with this book.
        /// </summary>
        public List<string> Tag { get; set; }
    }
}
