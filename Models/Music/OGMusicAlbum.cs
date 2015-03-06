namespace Simplr.OpenGraph.Models.Music
{
    public class OGMusicAlbum : OGAlbum
    {
        /// <summary>
        /// >=1 - Which disc of the song this album is on.
        /// </summary>
        public int Disc { get; set; }
        /// <summary>
        /// >=1 - Which track this album is.
        /// </summary>
        public int Track { get; set; }
    }
}
