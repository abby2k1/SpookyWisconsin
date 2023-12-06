using SGD.SpookyWisconsin.Entities;

namespace SDG.SpookyWisconsin.PL.Entities
{
    public partial class tblAddress : IEntity
    {
        public Guid Id { get; set; }
        public string SortField { get { return State.ToString(); } }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string ZIP { get; set; }
    }
}
