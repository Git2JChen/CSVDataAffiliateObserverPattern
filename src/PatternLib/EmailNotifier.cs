using System.Collections.Generic;

namespace PatternLib
{
    public class EmailNotifier : INotifier
    {
        public string UpdateObservers(IList<Affiliate> observers)
        {
            return "Email notification sent";
        }
    }
}