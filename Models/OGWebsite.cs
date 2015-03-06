using Simplr.OpenGraph.Contracts;
using Simplr.OpenGraph.Enums;

namespace Simplr.OpenGraph.Models
{
    public class OGWebsite : IOGTypeInternal
    {
        public OGObjectType Type { get { return OGObjectType.Website; } }
    }
}
