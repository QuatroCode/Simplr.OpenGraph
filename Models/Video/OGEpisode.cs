using Simplr.OpenGraph.Contracts;
using Simplr.OpenGraph.Enums;

namespace Simplr.OpenGraph.Models.Video
{
    public class OGEpisode : OGMovie, IOGTypeInternal
    {
        public override OGObjectType Type { get { return OGObjectType.Video_Episode; } }
        /// <summary>
        /// Which series this episode belongs to.
        /// </summary>
        public OGTvShow Series { get; set; }
    }
}
