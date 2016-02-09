namespace Base.SPApp.WebSite.Masterpages
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Base.SPApp.WebSite.Usercontrols;

    /// <summary>
    /// The Base App Master.
    /// </summary>
    public class BaseAppMaster : MasterPage
    {
        #region privates

        /// <summary>
        /// Load custom webcontrol
        /// </summary>
        private MainMenuControl MainMenuCtrl;

        #endregion privates

        #region protected

        /// <summary>
        /// PlaceHolderPageTitle webControl for binding.
        /// </summary>
        protected ContentPlaceHolder PlaceHolderPageTitle = new ContentPlaceHolder();
        protected Literal litTitle;

        protected ContentPlaceHolder PlaceHolderMainMenu = new ContentPlaceHolder();

        #endregion protected

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

                MainMenuCtrl = (MainMenuControl)LoadControl("~/_CONTROLTEMPLATES/BaseMenu/MainMenu.ascx");
                this.PlaceHolderMainMenu.Controls.Add(MainMenuCtrl);
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
