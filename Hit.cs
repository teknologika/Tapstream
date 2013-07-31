using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TapstreamMetrics.Sdk
{
    public sealed class Hit
    {

        public delegate void Complete(TSResponse response);

        private string trackerName;
        private string encodedTrackerName;
        private StringBuilder tags = null;

        public Hit(string hitTrackerName)
        {
            trackerName = hitTrackerName;
            encodedTrackerName = Uri.EscapeDataString(hitTrackerName);
        }

        public void AddTag(string tag)
        {
            if (tag.Length > 255)
            {
                Logging.Log(LogLevel.WARN, "Tapstream Warning: Hit tag exceeds 255 characters, it will not be included in the post (tag={0})", tag);
                return;
            }

            String encodedTag = Uri.EscapeDataString(tag);
            if(tags == null)
            {
                tags = new StringBuilder("__ts=");
            }
            else
            {
                tags.Append(",");
            }
            tags.Append(encodedTag);
        }

        public string TrackerName
        {
            get
            {
                return trackerName;
            }
        }

        public string EncodedTrackerName
        {
            get
            {
                return encodedTrackerName;
            }
        }

        public string PostData
        {
            get
            {
                return tags == null ? "" : tags.ToString();
            }
        }
    }
}