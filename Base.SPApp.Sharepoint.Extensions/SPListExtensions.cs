namespace Base.SPApp.Sharepoint.Extensions
{
    using System;
    using Microsoft.SharePoint;

    /// <summary>
    /// The SPList extensions class.
    /// </summary>
    public static class SPListExtensions
    {
        /// <summary>
        /// Add method for SPListCollection for no return an exception if no list return.
        /// </summary>
        /// <param name="list"></param>
        public static SPList TryGetList(this SPListCollection lists, String listName)
        {
            SPList list;

            try
            {
                list = lists[listName];
            }
            catch
            {
                list = null;
            }
            
            return list;
        }
    }
}
