namespace PatternLib
{
    public interface IAffiliate
    {
        int Id { get; set; }
        string Name { get; set; }
        bool Update();
    }
}