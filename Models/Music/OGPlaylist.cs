using Simplr.OpenGraph.Contracts;
using Simplr.OpenGraph.Enums;
using System.Collections.Generic;

namespace Simplr.OpenGraph.Models.Music
{
    public class OGPlaylist : IOGTypeInternal
    {
        public OGObjectType Type { get { return OGObjectType.Music_Playlist; } }
        /// <summary>
        /// The songs on this playlist.
        /// </summary>
        public List<OGMusicSong> Song { get; set; }
        /// <summary>
        /// The creator of this playlist.
        /// </summary>
        public OGProfile Creator { get; set; }
    }
}
