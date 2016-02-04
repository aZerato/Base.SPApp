namespace Base.SPApp.Sharepoint.Receivers.Extensions
{
    using System;
    using Microsoft.SharePoint;

    /// <summary>
    /// The SP Feature Receiver Properties extensions class.
    /// </summary>
    public static class SPFeatureReceiverPropertiesExtensions
    {
        #region publics

        /// <summary>
        /// Return the current scoped website.
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        public static SPWeb GetWeb(this SPFeatureReceiverProperties properties)
        {
            SPWeb site = null;

            try
            {
                if(properties.Feature.Parent is SPWeb)
                {
                    site = (SPWeb)properties.Feature.Parent;
                }
                else if (properties.Feature.Parent is SPSite)
                {
                    site = ((SPSite)properties.Feature.Parent).RootWeb;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to retrieve the current SPWeb, this feature is not site or web scoped.", ex);
            }

            return site;
        }

        #endregion publics
    }
}
