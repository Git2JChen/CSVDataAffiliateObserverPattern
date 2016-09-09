using System.Collections.Generic;

namespace PatternLib
{
    public class CSVDataFeed
    {
        private IList<Affiliate> _affiliates;

        public IList<Affiliate> Affiliates
        {
            get
            {
                return new List<Affiliate>
                {
                    new Affiliate()
                };
            } 
            set {}
        }

        public void Attach(Affiliate affiliate)
        {
            _affiliates = new List<Affiliate> { affiliate };
        }

        public void Dettach(Affiliate affiliate)
        {
            _affiliates = new List<Affiliate> { affiliate };
        }
    }
}