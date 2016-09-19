using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternLib
{
    interface ICSVDataFeed
    {
        decimal Price { get; set; }
        IList<Affiliate> Affiliates { get; set; }

        void Attach(Affiliate affiliate);
        void Detach(Affiliate affiliate);
        void Notify();
    }
}
