using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using umbraco.presentation.nodeFactory;

namespace afdsl_Web_Application.afdsl_UserControls.Gallery_Home_Page_UserControls
{
    public partial class afdsl_Gallery_HomePage : System.Web.UI.UserControl
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

        List<afdsl.BusinessLayer.afdsl.CustomStructs.galleryItem> galleryItemList = new List<afdsl.BusinessLayer.afdsl.CustomStructs.galleryItem>();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllBlogNodesByType(NodeNumber, TypeName);

            if (NumberOfPosts != 0)
            {
                rptGalleryHomeItems.DataSource = galleryItemList = galleryItemList.Take(NumberOfPosts).ToList();
            }
            else
            {
                rptGalleryHomeItems.DataSource = galleryItemList = galleryItemList.ToList();
            }
            rptGalleryHomeItems.DataBind();
        }

        private void GetAllBlogNodesByType(int NodeId, string typeName)
        {
            try
            {
                Node node = new Node(NodeId);
                foreach (Node childNode in node.Children)
                {
                    if (childNode.NodeTypeAlias == typeName)
                    {
                        afdsl.BusinessLayer.afdsl.CustomStructs.galleryItem _galleryItem = new afdsl.BusinessLayer.afdsl.CustomStructs.galleryItem();

                        _galleryItem.afdsl_galleryid = childNode.Id != 0 ? childNode.Id : 0;
                        _galleryItem.afdsl_galeryCreatorName = childNode.Name != null ? childNode.Name : string.Empty;
                        _galleryItem.afdsl_galleryCreatedDate = childNode.CreateDate != null ? childNode.CreateDate : DateTime.MinValue;
                        _galleryItem.afdsl_galleryTitle = childNode.GetProperty("ImageTitle").Value != null ? childNode.GetProperty("ImageTitle").Value : string.Empty;
                        _galleryItem.afdsl_galleryAltTag = childNode.GetProperty("imageAltTag").Value != null ? childNode.GetProperty("imageAltTag").Value : string.Empty;
                        _galleryItem.afdsl_gallerySrc = childNode.GetProperty("imageSrcAttribute").Value != null ? childNode.GetProperty("imageSrcAttribute").Value : string.Empty;
                        _galleryItem.afdsl_galleryThumb = childNode.GetProperty("imageSrcThumbnail").Value != null ? childNode.GetProperty("imageSrcThumbnail").Value : string.Empty;

                        galleryItemList.Add(_galleryItem);
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