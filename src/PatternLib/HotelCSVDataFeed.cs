using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternLib
{
    public class HotelCSVDataFeed : BaseDataFeed
    {
        private INotifier _notifier = new TwitterNotifier();

        public HotelCSVDataFeed(INotifier notifier) : base(notifier)
        {
            _notifier = notifier;
        }

        public override void Notify()
        {
            _notifier.UpdateObservers(_affiliates);
        }
    }
}
