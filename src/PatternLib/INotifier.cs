using System.Collections.Generic;

namespace PatternLib
{
    public interface INotifier
    {
        bool UpdateObservers(IList<Affiliate> observers);
    }

    public class Notifier : INotifier
    {
        public bool UpdateObservers(IList<Affiliate> observers)
        {
            return true;
        }
    }
}