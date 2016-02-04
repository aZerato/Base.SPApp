namespace Base.SPApp.WebSite.Masterpages
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// The Base App Master.
    /// </summary>
    public class BaseAppMaster : MasterPage
    {
        #region privates
        
        /// <summary>
        /// PlaceHolderPageTitle webControl for binding.
        /// </summary>
        protected ContentPlaceHolder PlaceHolderPageTitle = new ContentPlaceHolder();
        protected Literal litTitle;

        #endregion privates

        #region overrided

        /// <summary>
        /// CreateChildControls Method.
        /// </summary>
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            try
            {
                this.litTitle = new Literal();
                this.PlaceHolderPageTitle.Controls.Add(this.litTitle);
            }
            catch (Exception ex)
            {
                throw new Exception("BaseAppMaster.CreateChildControls problem.", ex);
            }
        }

        /// <summary>
        /// OnPreRender Method.
        /// </summary>
        /// <param name="e">Event argument params</param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            try
            {
                this.litTitle.Text = "BaseApp Master";
            }
            catch (Exception ex)
            {
                throw new Exception("BaseAppMaster.OnPreRender problem.", ex);
            }
        }

        #endregion overrided

    }
}
