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
            return "Twitter notification sent";
        }
    }
}
