using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afdsl.BusinessLayer.afdsl.CustomStructs
{
    public class blogItem
    {
        public int afdsl_id { get; set; }
        public string afdls_intro { get; set; }
        public string afdsl_Url { get; set; }
        public string afdsl_datePosted { get; set; }
        public string afdsl_blogTitle { get; set; }
        public string afdsl_creatorName { get; set; }
        public string afdsl_image { get; set; }
        public DateTime afdsl_CreatedDate { get; set; }
        public DateTime afdsl_Umbraco_CreatedDate { get; set; } 

        public string Truncate(string value, int maxLength)
        {
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}
