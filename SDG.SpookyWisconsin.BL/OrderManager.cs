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
using SDG.SpookyWisconsin.PL.Entities;

namespace SDG.SpookyWisconsin.BL
{
    public class OrderManager
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";

        public static int Insert(Order order, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblOrder row = new tblOrder();
                    //Fill the table - TODO: Fill in other columns when the database is connected
                    row.Id = new Guid();
                    row.InCartId = order.CartId;
                    row.OrderDate = order.OrderDate;
                    row.DeliveryDate = order.DeliverDate;


                    order.Id = row.Id;
                    dc.tblOrders.Add(row);
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
        public static int Update(Order order, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblOrder row = dc.tblOrders.FirstOrDefault(d => d.Id == order.Id);

                    //TODO: Fill in the updated fields once the database is completed
                    //ex: row.State = order.State...
                    row.InCartId = order.CartId;
                    row.OrderDate = order.OrderDate;
                    row.DeliveryDate = order.DeliverDate;


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

        public static Order LoadById(Guid id)
        {
            try
            {
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    var row = (from pd in dc.tblOrders
                               where pd.Id == id
                               select new
                               {
                                   Id = pd.Id,
                                   OrderDate = pd.OrderDate,
                                   DeliveryDate = pd.DeliveryDate,
                                   CartId = pd.InCartId
                                   //TODO - Joins and other fields

                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new Order
                        {
                            Id = row.Id,
                            OrderDate = row.OrderDate,
                            DeliverDate = row.DeliveryDate,
                            CartId = row.CartId
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

        public static List<Order> Load()
        {
            List<Order> rows = new List<Order>();

            using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
            {
                var orderes = (from pd in dc.tblOrders
                                      orderby pd.OrderDate
                                      select new
                                      {
                                          Id = pd.Id,
                                          OrderDate = pd.OrderDate,
                                          DeliveryDate = pd.DeliveryDate,
                                          CartId = pd.InCartId

                                      }).ToList();
                orderes.ForEach(pd => rows.Add(new Order
                {
                    Id = pd.Id,
                    OrderDate = pd.OrderDate,
                    DeliverDate = pd.DeliveryDate,
                    CartId = pd.CartId
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

                    tblOrder row = dc.tblOrders.FirstOrDefault(d => d.Id == id);

                    dc.tblOrders.Remove(row);
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
