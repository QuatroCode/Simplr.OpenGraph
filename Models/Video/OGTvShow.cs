using Simplr.OpenGraph.Contracts;
using Simplr.OpenGraph.Enums;

namespace Simplr.OpenGraph.Models.Video
{
    public class OGTvShow : OGMovie, IOGTypeInternal
    {
        public override OGObjectType Type { get { return OGObjectType.Video_Movie; } }
    }
}
