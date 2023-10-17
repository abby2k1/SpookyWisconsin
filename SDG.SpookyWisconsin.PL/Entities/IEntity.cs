namespace SGD.SpookyWisconsin.Entities
{
    public interface IEntity
    {
        //used by the managers to ensure they all have an Id
        Guid Id { get; set; }
        //Used for the sorting functionality with GenericManager
        string SortField { get; }
    }
}