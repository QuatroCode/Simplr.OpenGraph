using Simplr.OpenGraph.Contracts;
using Simplr.OpenGraph.Enums;

namespace Simplr.OpenGraph.Models
{
    public class OGProfile : IOGTypeInternal
    {
        public OGObjectType Type { get { return OGObjectType.Profile; } }
        /// <summary>
        /// A name normally given to an individual by a parent or self-chosen.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// A name inherited from a family or marriage and by which the individual is commonly known.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// A short unique string to identify them.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Enum (male, female) - Their gender.
        /// </summary>
        public OGGender? Gender { get; set; }
    }
}
