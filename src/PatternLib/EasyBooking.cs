namespace PatternLib
{
    public class EasyBooking : IAffiliate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Update()
        {
            return true;
        }
    }
}