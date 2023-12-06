using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.PL;

namespace SDG.SpookyWisconsin.BL
{
    public class AddressManager
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";

        public static int Insert(Address address, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblAddress row = new tblAddress();

                    //Fill the table
                    row.Id = new Guid();
                    row.Street = address.Street;
                    row.City = address.City;
                    row.State = address.State;
                    row.County = address.County;
                    row.ZIP = address.ZIP;

                    

                    address.Id = row.Id;
                    dc.tblAddresses.Add(row);
                    results = dc.SaveChanges();

                    if (rollback) dbContextTransaction.Rollback();

                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static int Update(Address address, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    //Find the row with a matching id
                    tblAddress row = dc.tblAddresses.FirstOrDefault(d => d.Id == address.Id);

                    //Update the table that matches the id
                    row.Street = address.Street;
                    row.City = address.City;
                    row.State = address.State;
                    row.County = address.County;
                    row.ZIP = address.ZIP;

                    results = dc.SaveChanges();

                    if (rollback) dbContextTransaction.Rollback();

                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Address LoadById(Guid id)
        {
            try
            {
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    var row = (from pd in dc.tblAddresses
                               where pd.Id == id
                               select new
                               {
                                   Id = pd.Id,
                                   Street = pd.Street,
                                   City = pd.City,
                                   County = pd.County,
                                   State = pd.State,
                                   ZIP = pd.ZIP

                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new Address
                        {
                            Id = row.Id,
                            County = row.County,
                            Street = row.Street,
                            City = row.City,
                            State = row.State,
                            ZIP = row.ZIP
                        };
                    }
                    else
                    {
                        throw new Exception(NOTFOUND_MESSAGE);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Address> Load()
        {
            List<Address> rows = new List<Address>();

            using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
            {
                var addresses = (from pd in dc.tblAddresses
                                 orderby pd.State
                                 select new
                                 {
                                     Id = pd.Id,
                                     Street = pd.Street,
                                     City = pd.City,
                                     County = pd.County,
                                     State = pd.State,
                                     Zip = pd.ZIP
                                 }).ToList();
                addresses.ForEach(pd => rows.Add(new Address
                {
                    Id = pd.Id,
                    County = pd.County,
                    Street = pd.Street,
                    City = pd.City,
                    State = pd.State,
                    ZIP = pd.Zip
                }));
            }
            return rows;
        }

        public static int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    //Find the row by it's id
                    tblAddress row = dc.tblAddresses.FirstOrDefault(d => d.Id == id);

                    //Remove the row from the table
                    dc.tblAddresses.Remove(row);
                    results = dc.SaveChanges();

                    //Rollback for testing
                    if (rollback) dbContextTransaction.Rollback();

                }
                return results;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
