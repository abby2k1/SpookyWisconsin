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


                    customer.Id = row.Id;
                    dc.tblCustomer.Add(row);
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

                    tblCustomer row = dc.tblCustomer.FirstOrDefault(d => d.Id == customer.Id);

                    //TODO: Fill in the updated fields once the database is completed
                    //ex: row.State = customer.State...


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

        public static Customer LoadById(int id)
        {
            try
            {
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    var row = (from pd in dc.tblCustomer
                               where pd.Id == id
                               select new
                               {
                                   Id = pd.Id,
                                   //TODO - Joins and other fields
                                   
                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new Customer
                        {
                            Id = row.Id,
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
                var customeres = (from pd in dc.tblCustomer
                                 orderby pd.FirstName
                                 select new
                                 {
                                     Id = pd.Id,
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

        public static int Delete(int id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblCustomer row = dc.tblCustomer.FirstOrDefault(d => d.Id == id);

                    dc.tblCustomer.Remove(row);
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
