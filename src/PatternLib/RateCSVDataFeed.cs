using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternLib
{
    public class RateCSVDataFeed : BaseDataFeed
    {
        private INotifier _notifier;

        public RateCSVDataFeed(INotifier notifier) : base(notifier)
        {
            _notifier = notifier;
        }

        public override void Notify()
        {
            _notifier.UpdateObservers(_affiliates);
        }
    }
}
