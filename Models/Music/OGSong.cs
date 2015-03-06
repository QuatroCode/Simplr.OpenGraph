using Simplr.OpenGraph.Contracts;
using Simplr.OpenGraph.Enums;
using System.Collections.Generic;

namespace Simplr.OpenGraph.Models.Music
{
    public class OGSong : IOGTypeInternal
    {
        public OGObjectType Type { get { return OGObjectType.Music_Song; } }
        /// <summary>
        /// >=1 - The song's length in seconds.
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// The album this song is from.
        /// </summary>
        public List<OGMusicAlbum> Album { get; set; }
        /// <summary>
        /// The musician that made this song.
        /// </summary>
        public List<OGProfile> Musician { get; set; }
    }
}
