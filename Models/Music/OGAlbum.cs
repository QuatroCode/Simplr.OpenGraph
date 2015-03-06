using Simplr.OpenGraph.Contracts;
using Simplr.OpenGraph.Enums;
using System;
using System.Collections.Generic;

namespace Simplr.OpenGraph.Models.Music
{
    public class OGAlbum : IOGTypeInternal
    {
        public OGObjectType Type { get { return OGObjectType.Music_Album; } }
        /// <summary>
        /// The song on this album.
        /// </summary>
        public List<OGMusicSong> Song { get; set; }
        /// <summary>
        /// The musician that made this song.
        /// </summary>
        public OGProfile Musician { get; set; }
        /// <summary>
        /// The date the album was released.
        /// </summary>
        public DateTime? ReleaseDate { get; set; }
    }
}
