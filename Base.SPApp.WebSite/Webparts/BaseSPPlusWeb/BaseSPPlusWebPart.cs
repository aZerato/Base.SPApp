namespace Base.SPApp.WebSite.Webparts
{
    using System.Web.UI;
    using System.Web.UI.WebControls.WebParts;
    using Base.SPApp.WebSite.Usercontrols;

    /// <summary>
    /// The BaseSPPlus WebPart.
    /// </summary>
    public class BaseSPPlusWebPart : WebPart
    {
        #region overrided

        /// <summary>
        /// Overide CreateChildControls Method.
        /// </summary>
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            try
            {
                BaseSPPlusControl baseSPPlusControl = (BaseSPPlusControl)this.Page.LoadControl("~/_CONTROLTEMPLATES/BaseApp/BaseSPPlus/BaseSPPlus.ascx");
                this.Controls.Add(baseSPPlusControl);
            }
            catch
            {
                this.Controls.Add(new LiteralControl("Error"));
            }
        }

        #endregion overrided
    }
}
