using System.Collections.Generic;

namespace PatternLib
{
    public class EmailNotifier : INotifier
    {
        public string UpdateObservers(IList<IAffiliate> observers)
        {
            var affiliates = string.Empty;

            foreach (var affiliate in observers)
            {
                affiliates += string.Format("{0} (ID={1}), ", affiliate.Name, affiliate.Id);
                affiliate.Update();
            }
            affiliates = affiliates.TrimEnd(new char[]{' ', ','});

            return "Email notification sent to: " + affiliates;
        }
    }
}