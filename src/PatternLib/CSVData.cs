using System.Collections.Generic;

namespace PatternLib
{
    public class CSVData
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