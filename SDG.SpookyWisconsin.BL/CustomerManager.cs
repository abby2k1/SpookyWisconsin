using Microsoft.EntityFrameworkCore.Storage;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.PL;
using SDG.SpookyWisconsin.PL.Entities;
using System.Xml.Linq;

namespace SDG.SpookyWisconsin.BL
{
    public class CustomerManager
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";

        public static int Insert(Customer customer, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblCustomer row = new tblCustomer();
                    //Fill the table - TODO: Fill in other columns when the database is connected
                    row.Id = new Guid();
                    row.MemberId = customer.MemberId;
                    row.AddressId = customer.AddressId;
                    row.Email = customer.Email;
                    row.Firstname = customer.FirstName;
                    row.Lastname = customer.LastName;


                    customer.Id = row.Id;
                    dc.tblCustomers.Add(row);
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
        public static int Update(Customer customer, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblCustomer row = dc.tblCustomers.FirstOrDefault(d => d.Id == customer.Id);

                    row.MemberId = customer.MemberId;
                    row.AddressId = customer.AddressId;
                    row.Email = customer.Email;
                    row.Firstname = customer.FirstName;
                    row.Lastname = customer.LastName;

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

        public static Customer LoadById(Guid id)
        {
            try
            {
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    var row = (from pd in dc.tblCustomers
                               where pd.Id == id
                               select new
                               {
                                   Id = pd.Id,
                                   MemberId = pd.MemberId,
                                   FirstName = pd.Firstname,
                                   LastName = pd.Lastname,
                                   AddressId = pd.AddressId,
                                   Email = pd.Email
                                   //TODO - Joins and other fields
                                   
                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new Customer
                        {
                            Id = row.Id,
                            FirstName = row.FirstName,
                            MemberId = row.MemberId,
                            LastName = row.LastName,
                            Email = row.Email,
                            AddressId = row.AddressId
                            ///TODO - Joins and other fields
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

        public static List<Customer> Load()
        {
            List<Customer> rows = new List<Customer>();

            using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
            {
                var customeres = (from pd in dc.tblCustomers
                                 orderby pd.Lastname
                                 select new
                                 {
                                     Id = pd.Id,
                                     MemberId = pd.MemberId,
                                     FirstName = pd.Firstname,
                                     LastName = pd.Lastname,
                                     AddressId = pd.AddressId,
                                     Email = pd.Email
                                     //TODO - Joins and other fields

                                 }).ToList();
                customeres.ForEach(pd => rows.Add(new Customer
                {
                    Id = pd.Id,
                    //TODO - Joins and other fields
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

                    tblCustomer row = dc.tblCustomers.FirstOrDefault(d => d.Id == id);

                    dc.tblCustomers.Remove(row);
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
