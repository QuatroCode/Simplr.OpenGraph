using Simplr.OpenGraph.Contracts;
using Simplr.OpenGraph.Enums;

namespace Simplr.OpenGraph.Models.Music
{
    public class OGRadioStation : IOGTypeInternal
    {
        public OGObjectType Type { get { return OGObjectType.Music_RadioStation; } }
        /// <summary>
        /// The creator of this station.
        /// </summary>
        public OGProfile Creator { get; set; }
    }
}
