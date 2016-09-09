using System.Collections.Generic;

namespace PatternLib
{
    public class CSVDataFeed
    {
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
    }
}