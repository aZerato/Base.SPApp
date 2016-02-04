namespace Base.SPApp.Sharepoint.Receivers
{
    using System;
    using Microsoft.SharePoint;
    using Sharepoint.Receivers.Extensions;

    /// <summary>
    /// The SP Feature Receiver class.
    /// </summary>
    public class MasterPageReceiver : SPFeatureReceiver
    {
        #region publics overrided
        
        /// <summary>
        /// Override Methode when feature is activated.
        /// </summary>
        /// <param name="properties"></param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SetDefaultMasterPage(properties, true);
        }
        
        /// <summary>
        /// Override Methode when feature is deactivated.
        /// </summary>
        /// <param name="properties"></param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SetDefaultMasterPage(properties, false);
        }

        /// <summary>
        /// Override Methode when feature is installed.
        /// </summary>
        /// <param name="properties"></param>
        public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        {
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// Override Methode when feature is uninstalled.
        /// </summary>
        /// <param name="properties"></param>
        public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        {
            //throw new System.NotImplementedException();
        }

        #endregion publics overrided

        #region privates

        /// <summary>
        /// Set Default MasterPage.
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="activation">if deactivation : set the original master / if activation : set the custom master.</param>
        private static void SetDefaultMasterPage(SPFeatureReceiverProperties properties, bool activation)
        {
            try
            {
                using (SPWeb web = properties.GetWeb())
                {
                    string urlCustomMaster = "/_catalogs/masterpage/BaseAppMasterPage.master";
                    string urlDefaultMaster = "/_catalogs/masterpage/default.master";

                    string masterName = string.Empty;
                    if (activation)
                    {
                        masterName = urlCustomMaster;

                        Uri masterUri = new Uri(web.Url + masterName);

                        web.MasterUrl = masterUri.AbsolutePath;
                        web.CustomMasterUrl = masterUri.AbsolutePath;

                        web.Update();
                    }
                    else
                    {
                        masterName = urlDefaultMaster;

                        Uri masterUri = new Uri(web.Url + masterName);

                        web.MasterUrl = masterUri.AbsolutePath;
                        web.CustomMasterUrl = masterUri.AbsolutePath;

                        web.Update();

                        // if necessary remove the custom master page.
                        SPFolder catalogsFolder = web.Folders["_catalogs"];
                        if (catalogsFolder != null)
                        {
                            SPFolder masterpageFolder = catalogsFolder.SubFolders["masterpage"];
                            if (masterpageFolder != null)
                            {
                                SPFile custMPFile = masterpageFolder.Files["BaseAppMasterPage.master"];
                                if (custMPFile != null)
                                {
                                    custMPFile.Delete();
                                }
                            }
                        }

                        web.Update();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Receivers.MasterPageReceiver.SetDefaultMasterPage problem", ex);
            }
        }

        #endregion privates
    }
}
