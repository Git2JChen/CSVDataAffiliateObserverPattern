using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternLib
{
    public class TwitterNotifier : INotifier
    {
        public string UpdateObservers(IList<IAffiliate> observers)
        {
            var affiliates = string.Empty;

            foreach (var affiliate in observers)
            {
                affiliates += string.Format("{0} (ID={1}), ", affiliate.Name, affiliate.Id);
                affiliate.Update();
            }
            affiliates = affiliates.TrimEnd(new char[] { ' ', ',' });

            return "Twitter notification sent to: " + affiliates;
        }
    }
}
