using System;

namespace Simplr.OpenGraph.Models
{
    public class OGAudio
    {
        /// <summary>
        /// An audio URL which should represent your object within the graph.
        /// </summary>
        public Uri Url { get; set; }
        /// <summary>
        /// An alternate url to use if the webpage requires HTTPS.
        /// </summary>
        public Uri SecureUrl { get; set; }
        /// <summary>
        /// A MIME type for this image. E.g. http://en.wikipedia.org/wiki/Internet_media_type
        /// </summary>
        public string Type { get; set; }

        public OGAudio()
        {

        }
        public OGAudio(Uri uri)
        {
            Url = uri;
        }
        public OGAudio(Uri uri, Uri secureUrl, string type)
        {
            Url = uri;
            SecureUrl = secureUrl;
            Type = type;
        }
    }
}
