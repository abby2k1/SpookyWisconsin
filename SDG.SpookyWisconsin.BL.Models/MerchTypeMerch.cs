namespace SDG.SpookyWisconsin.BL.Models;

public class MerchTypeMerch
{
    // many to many relationship between MerchType and Merch
    public Guid Id;
    public Guid MerchTypeId;
    public Guid MerchId;
}