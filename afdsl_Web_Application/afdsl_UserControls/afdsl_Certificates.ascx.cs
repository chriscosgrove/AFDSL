using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using umbraco.presentation.nodeFactory;

namespace afdsl_Web_Application.afdsl_UserControls
{
    public partial class afdsl_Certificates : System.Web.UI.UserControl
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

        List<afdsl.BusinessLayer.afdsl.CustomStructs.certificateItem> CertificateItemList = new List<afdsl.BusinessLayer.afdsl.CustomStructs.certificateItem>();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAllBlogNodesByType(NodeNumber, TypeName);

            if (NumberOfPosts != 0)
            {
                rptBlogItems.DataSource = CertificateItemList = CertificateItemList.Take(NumberOfPosts).ToList();
            }
            else
            {
                rptBlogItems.DataSource = CertificateItemList = CertificateItemList.ToList();
            }
            rptBlogItems.DataBind();
        }

        private void GetAllBlogNodesByType(int NodeId, string typeName)
        {
            afdsl.BusinessLayer.afdsl.CustomStructs.certificateItem certClass = new afdsl.BusinessLayer.afdsl.CustomStructs.certificateItem();
            try
            {
                Node node = new Node(NodeId);
                foreach (Node childNode in node.Children)
                {
                    if (childNode.NodeTypeAlias == typeName)
                    {
                        afdsl.BusinessLayer.afdsl.CustomStructs.certificateItem _certificateItem = new afdsl.BusinessLayer.afdsl.CustomStructs.certificateItem();

                        _certificateItem.afdsl_Url = childNode.NiceUrl != string.Empty ? childNode.NiceUrl : string.Empty;
                        _certificateItem.afdsl_datePosted = childNode.CreateDate.ToShortDateString() != null ? childNode.CreateDate.ToShortDateString() : string.Empty;
                        _certificateItem.afdsl_CertificatePDF = childNode.GetProperty("uploadCertificate").Value != null ? childNode.GetProperty("uploadCertificate").Value : string.Empty;
                        _certificateItem.afdsl_CertificateTitle = childNode.GetProperty("titleOfCertificate").Value != null ? childNode.GetProperty("titleOfCertificate").Value : string.Empty;
                        CertificateItemList.Add(_certificateItem);
                    }
                    if (childNode.Children.Count > 0)
                    {
                        GetAllBlogNodesByType(childNode.Id, TypeName);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                certClass = null;
                //Dispose
            }
        }
    }
}