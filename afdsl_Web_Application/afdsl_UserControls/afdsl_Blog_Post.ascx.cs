using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using umbraco.presentation.nodeFactory;
using afdsl.BusinessLayer.afdsl.CustomStructs;
using System.Text.RegularExpressions;

namespace afdsl_Web_Application.afdsl_UserControls
{
    public partial class afdsl_Blog_Post : System.Web.UI.UserControl
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
               //rptBlogItem.DataSource = blogItemList.OrderBy(x => x.afdsl_id).Take(NumberOfPosts).ToList();
               rptBlogItem.DataSource = blogItemList.OrderByDescending(x => x.afdsl_id).ToList().Take(NumberOfPosts);
           }
           else
           {
               rptBlogItem.DataSource = blogItemList = blogItemList.ToList();
           }
           rptBlogItem.DataBind();
        }

        
        private void GetAllBlogNodesByType(int NodeId, string typeName)
        {
            afdsl.BusinessLayer.afdsl.CustomStructs.blogItem blogClass = new blogItem();
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
                        _blogItem.afdsl_Umbraco_CreatedDate = childNode.CreateDate;
                        truncateBlog = childNode.GetProperty("bodyOfContentBlog").Value != string.Empty ? childNode.GetProperty("bodyOfContentBlog").Value : string.Empty;
                        string regexBlog = StripTagsRegex(truncateBlog);
                        _blogItem.afdls_intro = blogClass.Truncate(regexBlog, 150);

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
            }
            finally
            {
                //Dispose
            }
        }

        public static string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }
    }
}









       
        