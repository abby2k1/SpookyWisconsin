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
    public class CartManager
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";

        public static int Insert(Cart cart, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblCart row = new tblCart();
                    //Fill the table - TODO: Fill in other columns when the database is connected
                    row.Id = new Guid();


                    cart.Id = row.Id;
                    dc.tblCart.Add(row);
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
        public static int Update(Cart cart, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblCart row = dc.tblCart.FirstOrDefault(d => d.Id == cart.Id);

                    //TODO: Fill in the updated fields once the database is completed
                    //ex: row.State = cart.State...


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

        public static Cart LoadById(int id)
        {
            try
            {
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    var row = (from pd in dc.tblCart
                               where pd.Id == id
                               select new
                               {
                                   Id = pd.Id,
                                   //TODO - Joins and other fields

                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new Cart
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

        public static List<Cart> Load()
        {
            List<Cart> rows = new List<Cart>();

            using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
            {
                var cartes = (from pd in dc.tblCart
                                      orderby pd.FirstName
                                      select new
                                      {
                                          Id = pd.Id,
                                          //TODO - Joins and other fields

                                      }).ToList();
                cartes.ForEach(pd => rows.Add(new Cart
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

                    tblCart row = dc.tblCart.FirstOrDefault(d => d.Id == id);

                    dc.tblCart.Remove(row);
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
