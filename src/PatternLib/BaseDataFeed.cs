using System.Collections.Generic;
using System.Linq;

namespace PatternLib
{
    public class BaseDataFeed
    {
        protected decimal _price;
        protected IList<IAffiliate> _affiliates = new List<IAffiliate>();

        private INotifier _notifier = new EmailNotifier();

        public BaseDataFeed(INotifier notifier)
        {
            _notifier = notifier;
        }

        public IList<IAffiliate> Affiliates
        {
            get
            {
                return _affiliates;
            } 
            set { _affiliates = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public void Attach(IAffiliate easyBooking)
        {
            _affiliates.Add(easyBooking);
        }

        public void Detach(IAffiliate easyBooking)
        {
            var index = _affiliates.Select(a => a.Id)
                        .ToList().IndexOf(easyBooking.Id);

            _affiliates.RemoveAt(index);
        }

        public virtual void Notify()
        {
            _notifier.UpdateObservers(_affiliates);
        }
    }
}