using System;

namespace Simplr.OpenGraph.Models
{
    public class OGVideo
    {
        /// <summary>
        /// An video URL which should represent your object within the graph.
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
        /// <summary>
        /// The number of pixels wide.
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// The number of pixels high.
        /// </summary>
        public int Height { get; set; }

        public OGVideo()
        {

        }
        public OGVideo(Uri uri)
        {
            Url = uri;
        }
        public OGVideo(Uri uri, Uri secureUrl, string type, int width, int height)
        {
            Url = uri;
            SecureUrl = secureUrl;
            Type = type;
            Width = width;
            Height = height;
        }
    }
}
