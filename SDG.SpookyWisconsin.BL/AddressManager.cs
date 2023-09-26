using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.PL;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;


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
                    //Fill the table - TODO: Fill in other columns when the database is connected
                    row.Id = new Guid();
                    

                    address.Id = row.Id;
                    dc.tblAddress.Add(row);
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

                    tblAddress row = dc.tblAddress.FirstOrDefault(d => d.Id == address.Id);

                    //TODO: Fill in the updated fields once the database is completed
                    //ex: row.State = address.State...
                  

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

        public static Address LoadById(int id)
        {
            try
            {
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    var row = (from pd in dc.tblAddress
                               where pd.Id == id
                               select new
                               {
                                   Id = pd.Id,
                                   Street = pd.Street,
                                   City = pd.City,
                                   Country = pd.Country,
                                   State = pd.State,
                                   Zip = pd.ZIP

                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new Address
                        {
                            Id = row.Id,
                            Country = row.Country,
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
                var addresses = (from pd in dc.tblAddress
                                 orderby pd.FirstName
                                 select new
                                 {
                                     Id = pd.Id,
                                     Street = pd.Street,
                                     City = pd.City,
                                     Country = pd.Country,
                                     State = pd.State,
                                     Zip = pd.ZIP
                                 }).ToList();
                addresses.ForEach(pd => rows.Add(new Address
                {
                    Id = pd.Id,
                    Country = pd.Country,
                    Street = row.Street,
                    City = pd.City,
                    State = pd.State,
                    ZIP = pd.ZIP
                }));
            }
            return rows;
        }

        public static int Delete(int id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblAddress row = dc.tblAddress.FirstOrDefault(d => d.Id == id);

                    dc.tblAddress.Remove(row);
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
    }
}
