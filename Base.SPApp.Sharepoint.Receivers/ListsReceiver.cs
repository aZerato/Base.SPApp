namespace Base.SPApp.Sharepoint.Receivers
{
    using System;
    using Microsoft.SharePoint;
    using Sharepoint.Extensions;
    using Sharepoint.Receivers.Extensions;

    /// <summary>
    /// The SP Feature Receiver class.
    /// </summary>
    public class ListsReceiver : SPFeatureReceiver
    {
        #region publics overrided

        /// <summary>
        /// Override Methode when feature is activated.
        /// </summary>
        /// <param name="properties"></param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            AddListItems(properties);
        }

        /// <summary>
        /// Override Methode when feature is deactivated.
        /// </summary>
        /// <param name="properties"></param>
        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            DeleteLists(properties);
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
        /// Add default items to list.
        /// </summary>
        /// <param name="properties"></param>
        private static void AddListItems(SPFeatureReceiverProperties properties)
        {
            try
            {
                using (SPWeb web = properties.GetWeb())
                {
                    // add default item to the BaseList
                    SPList baseList = web.Lists.TryGetList("BaseList");
                    if (baseList != null)
                    {
                        SPListItem item = baseList.Items.Add();
                        item["Title"] = "Sample 1";
                        item["Content"] = "Sample 1 Content";
                        item.Update();

                        SPListItem item2 = baseList.Items.Add();
                        item2["Title"] = "Sample 2";
                        item2["Content"] = "Sample 2 Content";
                        item2.Update();

                        SPListItem item3 = baseList.Items.Add();
                        item3["Title"] = "Sample 3";
                        item3["Content"] = "Sample 3 Content";
                        item3.Update();

                        SPListItem item4 = baseList.Items.Add();
                        item4["Title"] = "Sample 4";
                        item4["Content"] = "Sample 4 Content";
                        item4.Update();

                        SPListItem item5 = baseList.Items.Add();
                        item5["Title"] = "Sample 5";
                        item5["Content"] = "Sample 5 Content";
                        item5.Update();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Receivers.ListsReceiver.AddListItems problem", ex);
            }
        }

        /// <summary>
        /// Delete lists.
        /// </summary>
        /// <param name="properties"></param>
        private static void DeleteLists(SPFeatureReceiverProperties properties)
        {
            try
            {
                if (properties.Definition.Properties["ListsToDelete"] != null
                    && !String.IsNullOrEmpty(properties.Definition.Properties["ListsToDelete"].Value))
                {
                    using (SPWeb web = properties.GetWeb())
                    {
                        // loop on all lists name to delete
                        // <Feature>
                        //  ...
                        //  <Properties>
                        //    <Property Key="ListsToDelete" Value="NameOfListToDelete"/>
                        //  </Properties>
                        // </Feature>
                        foreach (string filename in properties.Definition.Properties["ListsToDelete"].Value.Split(','))
                        {
                            SPList list = web.Lists.TryGetList(filename);
                            if (list != null)
                            {
                                list.Delete();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Receivers.ListsReceiver.DeleteLists problem", ex);
            }
        }

        #endregion privates
    }
}
