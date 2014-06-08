using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using umbraco.presentation.nodeFactory;

namespace afdsl_Web_Application.afdsl_UserControls.Hero_Gallery_Item_UserControls
{
    public partial class afdsl_Hero_Gallery_Item : System.Web.UI.UserControl
    {
        string truncateBlog = string.Empty;
        int _nodeNumber;
        public int NodeNumber
        {
            get
            {
                return this._nodeNumber;
            }
            set
            {
                this._nodeNumber = value;
            }
        }

        string _typeName;
        public string TypeName
        {
            get
            {
                return this._typeName;
            }
            set
            {
                this._typeName = value;
            }
        }

        int _NumberOfPosts;
        public int NumberOfPosts
        {
            get
            {
                return this._NumberOfPosts;
            }
            set
            {
                this._NumberOfPosts = value;
            }
        }

        List<afdsl.BusinessLayer.afdsl.CustomStructs.heroGalleryItem> heroGalleryItem = new List<afdsl.BusinessLayer.afdsl.CustomStructs.heroGalleryItem>();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllBlogNodesByType(NodeNumber, TypeName);

            if (NumberOfPosts != 0)
            {
                rptHeroGallery.DataSource = heroGalleryItem = heroGalleryItem.Take(NumberOfPosts).ToList();
            }
            else
            {
                rptHeroGallery.DataSource = heroGalleryItem = heroGalleryItem.ToList();
            }
            rptHeroGallery.DataBind();
        }

        private void GetAllBlogNodesByType(int NodeId, string typeName)
        {
            try
            {
                int nodeId;
                string nodeIdString;

                Node node = new Node(NodeId);
                foreach (Node childNode in node.Children)
                {
                    if (childNode.NodeTypeAlias == typeName)
                    {
                        afdsl.BusinessLayer.afdsl.CustomStructs.heroGalleryItem _heroGalleryItem = new afdsl.BusinessLayer.afdsl.CustomStructs.heroGalleryItem();

                        _heroGalleryItem.afdsl_Hero_Galleryid = childNode.Id != 0 ? childNode.Id : 0;
                        _heroGalleryItem.afdsl_Hero_Heading =  childNode.GetProperty("heroHeading").Value != null ? childNode.GetProperty("heroHeading").Value : string.Empty;
                        _heroGalleryItem.afdsl_Hero_Sub_Heading = childNode.GetProperty("heroSubHeading").Value != null ? childNode.GetProperty("heroSubHeading").Value : string.Empty;
                        _heroGalleryItem.afdsl_Hero_Image_Src = childNode.GetProperty("heroImage").Value != null ? childNode.GetProperty("heroImage").Value : string.Empty;
                        _heroGalleryItem.afdsl_Hero_Gallery_AltTag = childNode.GetProperty("heroImageAltTag").Value != null ? childNode.GetProperty("heroImageAltTag").Value : string.Empty;

                        nodeIdString = childNode.GetProperty("heroLinkToPage").Value != null ? childNode.GetProperty("heroLinkToPage").Value : string.Empty;
                        int.TryParse(nodeIdString, out nodeId);
                        _heroGalleryItem.afdsl_Hero_Link_Address = umbraco.library.NiceUrl(nodeId);

                            //string afdsl_Hero_Display { get; set; }
                                 //string afdsl_Hero_Link_Address { get; set; }
                                 //string afdsl_Hero_Gallery_AltTag { get; set; }
                                 //string afdsl_Hero_Image_Src { get; set; }



                        heroGalleryItem.Add(_heroGalleryItem);
                    }
                    if (childNode.Children.Count > 0)
                    {
                        GetAllBlogNodesByType(childNode.Id, TypeName);
                    }
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                //Dispose
            }
        }
    }
}