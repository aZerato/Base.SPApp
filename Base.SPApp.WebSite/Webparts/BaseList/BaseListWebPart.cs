namespace Base.SPApp.WebSite.Webparts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using Microsoft.SharePoint;
    using Sharepoint.Extensions;

    /// <summary>
    /// The BaseList WebPart.
    /// </summary>
    public class BaseListWebPart : WebPart
    {
        #region WebPart Parameters

        [Category("Configuration"), Personalizable(PersonalizationScope.Shared), WebBrowsable(true)]
        [WebDisplayName("Maximum results return")]
        [WebDescription("Set maximum results return")]
        public int MaximumResults { get; set; }
        
        #endregion

        #region overrided

        /// <summary>
        /// Overide CreateChildControls Method.
        /// </summary>
        protected override void CreateChildControls()
         {
             base.CreateChildControls();

             Panel contentDiv = new Panel();
             contentDiv.CssClass = "content";

             HtmlGenericControl h2 = new HtmlGenericControl("h2");
             h2.InnerHtml = "WebPart BaseList";
             contentDiv.Controls.Add(h2);

             try
             {
                 List<SPListItem> items = new List<SPListItem>();

                 using (SPWeb web = SPContext.Current.Web)
                 {
                     SPList baseList = web.Lists.TryGetList("BaseList");
                     if (baseList != null)
                     {
                        if (MaximumResults != 0)
                        {
                            items = baseList.Items.OfType<SPListItem>().OrderBy(it => it.Title).Take(MaximumResults).ToList();
                        }
                        else
                        {
                            items = baseList.Items.OfType<SPListItem>().OrderBy(it => it.Title).ToList();
                        }
                        
                     }
                 }

                 if (items.Count > 0)
                 {
                     Table results = new Table();
                    
                     foreach (SPListItem item in items)
                     {
                         TableRow tr = new TableRow();

                         TableCell tc = new TableCell() { Text = item.Title };
                         tr.Controls.Add(tc);

                         TableCell tc2 = new TableCell() { Text = item["Content"].ToString() };
                         tr.Controls.Add(tc2);

                         TableCell tc3 = new TableCell() { Text = item["Length"].ToString() };
                         tr.Controls.Add(tc3);

                         results.Controls.Add(tr);
                     }

                     contentDiv.Controls.Add(results);
                 }
             }
             catch(Exception ex)
             {
                 throw new Exception("Base.SPApp.WebSite.Webparts.BaseListWebPart.CreateChildControls problem.", ex);
             }

             this.Controls.Add(contentDiv);
         }

        #endregion overrided
    }
}
