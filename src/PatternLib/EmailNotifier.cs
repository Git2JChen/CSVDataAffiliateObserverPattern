using System.Collections.Generic;

namespace PatternLib
{
    public class EmailNotifier : INotifier
    {
        public string UpdateObservers(IList<IAffiliate> observers)
        {
            return string.Format("Email notification sent to: {0} (ID={1})", observers[0].Name, observers[0].Id);
        }
    }
}