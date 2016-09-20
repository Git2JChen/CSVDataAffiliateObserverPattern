using System.Collections.Generic;
using System.Linq;

namespace PatternLib
{
    public class BaseDataFeed
    {
        private INotifier _notifier;
        protected decimal _price;
        protected IList<Affiliate> _affiliates = new List<Affiliate>();

        public BaseDataFeed(INotifier notifier)
        {
            _notifier = notifier;
        }

        public IList<Affiliate> Affiliates
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

        public void Attach(Affiliate affiliate)
        {
            _affiliates.Add(affiliate);
        }

        public void Detach(Affiliate affiliate)
        {
            var index = _affiliates.Select(a => a.Id)
                        .ToList().IndexOf(affiliate.Id);

            _affiliates.RemoveAt(index);
        }

        public virtual void Notify()
        {
            _notifier.UpdateObservers(_affiliates);
        }
    }
}