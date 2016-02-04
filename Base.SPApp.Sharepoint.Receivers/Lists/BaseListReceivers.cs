namespace Base.SPApp.Sharepoint.Receivers.Lists
{
    using Microsoft.SharePoint;

    /// <summary>
    /// The BaseList receivers class.
    /// </summary>
    public class BaseListReceivers : SPItemEventReceiver
    {
        #region publics
        #endregion publics

        /// <summary>
        /// Event when item is adding to list.
        /// </summary>
        /// <param name="properties"></param>
        public override void ItemAdding(SPItemEventProperties properties)
        {
            base.ItemAdding(StringLength(properties));
        }


        /// <summary>
        /// Event when item is updating.
        /// </summary>
        /// <param name="properties"></param>
        public override void ItemUpdating(SPItemEventProperties properties)
        {
            base.ItemUpdating(StringLength(properties));
        }

        #region privates

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private SPItemEventProperties StringLength(SPItemEventProperties properties)
        {
            properties.AfterProperties["Length"] = properties.AfterProperties["Title"].ToString().Length + properties.AfterProperties["Content"].ToString().Length;

            return properties;
        }

        #endregion privates
    }
}
