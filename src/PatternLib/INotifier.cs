using System.Collections.Generic;

namespace PatternLib
{
    public interface INotifier
    {
        string UpdateObservers(IList<IAffiliate> observers);
    }
}