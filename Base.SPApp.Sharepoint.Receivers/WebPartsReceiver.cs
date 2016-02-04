namespace Base.SPApp.Sharepoint.Receivers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.SharePoint;
    using Sharepoint.Receivers.Extensions;

    /// <summary>
    /// The SP Feature Receiver class.
    /// </summary>
    public class WebPartsReceiver : SPFeatureReceiver
    {
        #region publics overrided

        /// <summary>
        /// Override Methode when feature is activated.
        /// </summary>
        /// <param name="properties"></param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// Override Methode when feature is deactivated.
        /// </summary>
        /// <param name="properties"></param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            DeleteWebParts(properties);
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
        /// Delete webparts.
        /// </summary>
        /// <param name="properties"></param>
        private static void DeleteWebParts(SPFeatureReceiverProperties properties)
        {
            try
            {
                //System.Diagnostics.Debugger.Launch(); you need to use stsadm for launch debugger

                if (properties.Definition.Properties["WebPartsToDelete"] != null
                    && !String.IsNullOrEmpty(properties.Definition.Properties["WebPartsToDelete"].Value))
                {
                    using (SPWeb web = properties.GetWeb())
                    {
                        SPList list = web.GetCatalog(SPListTemplateType.WebPartCatalog);
                        if (list != null)
                        {
                            string[] wpToDelete = properties.Definition.Properties["WebPartsToDelete"].Value.Split(',');
                            IEnumerable<SPListItem> wpToDeleteList = list.Items.OfType<SPListItem>().Where(it => wpToDelete.Contains(it.Name));

                            if (wpToDeleteList.Count() > 0)
                            {
                                foreach (SPListItem toDelete in wpToDeleteList)
                                {
                                    list.Items.DeleteItemById(toDelete.ID);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Receivers.WebPartsReceiver.DeleteWebParts problem", ex);
            }
        }

        #endregion privates
    }
}
