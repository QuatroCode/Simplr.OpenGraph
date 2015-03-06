using Simplr.OpenGraph.Contracts;
using Simplr.OpenGraph.Enums;
using System;
using System.Collections.Generic;

namespace Simplr.OpenGraph.Models.Video
{
    public class OGMovie : IOGTypeInternal
    {
        public virtual OGObjectType Type { get { return OGObjectType.Video_Movie; } }
        /// <summary>
        /// Actors in the movie.
        /// </summary>
        public List<OGActor> Actor { get; set; }
        /// <summary>
        /// Directors of the movie.
        /// </summary>
        public List<OGProfile> Director { get; set; }
        /// <summary>
        /// Writers of the movie.
        /// </summary>
        public List<OGProfile> Writer { get; set; }
        /// <summary>
        /// >=1 - The movie's length in seconds.
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// The date the movie was released.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }
        /// <summary>
        /// Tag words associated with this movie.
        /// </summary>
        public List<string> Tag { get; set; }
    }
}
