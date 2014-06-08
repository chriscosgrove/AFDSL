using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afdsl.BusinessLayer.afdsl.CustomStructs
{
    public class heroGalleryItem
    {
        public int afdsl_Hero_Galleryid { get; set; }
        public string afdsl_Hero_Heading { get; set; }
        public string afdsl_Hero_Sub_Heading { get; set; }
        public string afdsl_Hero_Display { get; set; }
        public string afdsl_Hero_Link_Address { get; set; }
        public string afdsl_Hero_Gallery_AltTag { get; set; }
        public string afdsl_Hero_Image_Src { get; set; }


        public string afdsl_Hero_GaleryCreatorName { get; set; }
        public DateTime afdsl_Hero_GalleryCreatedDate { get; set; }

        public string Truncate(string value, int maxLength)
        {
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}
