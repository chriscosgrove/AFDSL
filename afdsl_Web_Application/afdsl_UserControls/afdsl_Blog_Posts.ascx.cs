using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using umbraco.presentation.nodeFactory;
using afdsl.BusinessLayer;
using afdsl.BusinessLayer.afdsl.CustomStructs;

namespace afdsl_Web_Application.afdsl_UserControls
{
    public partial class afdsl_Blog_Posts : System.Web.UI.UserControl
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

        List<afdsl.BusinessLayer.afdsl.CustomStructs.blogItem> blogItemList = new List<afdsl.BusinessLayer.afdsl.CustomStructs.blogItem>();

        protected void Page_Load(object sender, EventArgs e)
        {
           GetAllBlogNodesByType(NodeNumber, TypeName);

           if (NumberOfPosts != 0)
           {
               rptBlogItems.DataSource = blogItemList = blogItemList.Take(NumberOfPosts).ToList();
           }
           else
           {
               rptBlogItems.DataSource = blogItemList = blogItemList.OrderByDescending(x => x.afdsl_id).ToList();
           }
           rptBlogItems.DataBind();

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
                        afdsl.BusinessLayer.afdsl.CustomStructs.blogItem _blogItem = new afdsl.BusinessLayer.afdsl.CustomStructs.blogItem();
                        _blogItem.afdsl_id = childNode.Id != 0 ? childNode.Id : 0;
                        _blogItem.afdsl_Url = childNode.NiceUrl != string.Empty ? childNode.NiceUrl : string.Empty;
                        _blogItem.afdsl_blogTitle = childNode.Name != null ? childNode.Name : string.Empty;
                        _blogItem.afdsl_image = childNode.GetProperty("imageForBlog").Value != null ? childNode.GetProperty("imageForBlog").Value : "/Web_Assets/Images/afdsl_BlogImage.png";
                        _blogItem.afdsl_datePosted = childNode.CreateDate.ToShortDateString() != null ? childNode.CreateDate.ToShortDateString() : string.Empty;

                        truncateBlog = childNode.GetProperty("bodyOfContentBlog").Value != string.Empty ? childNode.GetProperty("bodyOfContentBlog").Value : string.Empty;

                        _blogItem.afdls_intro = _blogItem.Truncate(truncateBlog, 230);

                        blogItemList.Add(_blogItem);
                    }
                    if (childNode.Children.Count > 0)
                    {
                        GetAllBlogNodesByType(childNode.Id, TypeName);
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                //Dispose
            }
        }
    }
}










       
        