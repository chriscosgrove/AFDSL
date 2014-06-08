using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;

namespace afdsl.BusinessLayer.afdsl.CustomStructs
{
    public class galleryItem
    {
        public int afdsl_galleryid { get; set; }
        public string afdsl_galleryTitle { get; set; }
        public string afdsl_gallerySrc { get; set; }
        public string afdsl_galeryCreatorName { get; set; }
        public DateTime afdsl_galleryCreatedDate { get; set; }
        public string afdsl_galleryAltTag { get; set; }
        public string afdsl_galleryThumb { get; set; }

        public string Truncate(string value, int maxLength)
        {
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}
