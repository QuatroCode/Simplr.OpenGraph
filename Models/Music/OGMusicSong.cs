namespace Simplr.OpenGraph.Models.Music
{
    public class OGMusicSong : OGSong
    {
        /// <summary>
        /// >=1 - Which disc of the album this song is on.
        /// </summary>
        public int Disc { get; set; }
        /// <summary>
        /// >=1 - Which track this song is.
        /// </summary>
        public int Track { get; set; }
    }
}
