using Simplr.OpenGraph.Contracts;
using Simplr.OpenGraph.Enums;
using System;
using System.Collections.Generic;

namespace Simplr.OpenGraph.Models
{
    public class OGMetadata : IOGTypeInternal
    {
        /// <summary>
        /// The title of your object as it should appear within the graph, e.g., "The Rock".
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The type of your object, e.g., "video.movie". Depending on the type you specify, other properties may also be required.
        /// </summary>
        public OGObjectType Type
        {
            get { return OGObjectType.Website; }
        }
        /// <summary>
        /// An image URL which should represent your object within the graph.
        /// </summary>
        public List<OGImage> Image { get; set; }
        /// <summary>
        /// The canonical URL of your object that will be used as its permanent ID in the graph, e.g., "http://www.imdb.com/title/tt0117500/".
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// A URL to an audio file to accompany this object.
        /// </summary>
        public OGAudio Audio { get; set; }
        /// <summary>
        /// A one to two sentence description of your object.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The word that appears before this object's title in a sentence. An enum of (a, an, the, "", auto). If auto is chosen, the consumer of your data should chose between "a" or "an". Default is "" (blank).
        /// </summary>
        public OGDeterminer? Determiner { get; set; }
        /// <summary>
        /// The locale these tags are marked up in. Of the format language_TERRITORY. Default is en_US.
        /// </summary>
        public string Locale { get; set; }
        /// <summary>
        /// An array of other locales this page is available in.
        /// </summary>
        public List<string> LocaleAlternate { get; set; }
        /// <summary>
        /// If your object is part of a larger web site, the name which should be displayed for the overall site. e.g., "IMDb".
        /// </summary>
        public string SiteName { get; set; }
        /// <summary>
        /// A URL to a video file that complements this object.
        /// </summary>
        public OGVideo Video { get; set; }
    }
}
