using System.Collections.Generic;
using System.Linq;

namespace PatternLib
{
    public class CSVDataFeed
    {
        private IList<Affiliate> _affiliates = new List<Affiliate>();

        public IList<Affiliate> Affiliates
        {
            get
            {
                return _affiliates;
            } 
            set { _affiliates = value; }
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
    }
}