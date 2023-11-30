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
using SGD.SpookyWisconsin.BL;
using Microsoft.EntityFrameworkCore;

namespace SDG.SpookyWisconsin.BL
{
    public class OrderManager : GenericManager<tblOrder>
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";
        //injecting the connection string 
        public OrderManager(DbContextOptions<SpookyWisconsinEntities> options) : base(options)
        {

        }

        public int Insert(Order order, bool rollback = false)
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
                    row.OrderDate = order.OrderDate;
                    //row.ShipDate = order.ShipDate;


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
        public int Update(Order order, bool rollback = false)
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
                    row.OrderDate = order.OrderDate;
                    //row.ShipDate = order.ShipDate;


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

        public Order LoadById(Guid id)
        {
            try
            {
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    var row = (from pd in dc.tblOrders
                               join c in dc.tblCustomers on pd.CustomerId equals c.Id
                               where pd.Id == id
                               select new
                               {
                                   Id = pd.Id,
                                   OrderDate = pd.OrderDate,
                                   CustomerId = pd.CustomerId,
                                   //ShipDate = pd.ShipDate,
                                   CustomerName = c.Firstname + " " + c.Lastname
                                   

                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new Order
                        {
                            Id = row.Id,
                            OrderDate = row.OrderDate,
                            CustomerId = row.CustomerId,
                            //ShipDate = row.ShipDate,
                            //CustomerName= row.CustomerName
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

        public List<Order> Load()
        {
            List<Order> rows = new List<Order>();

            using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
            {
                var orderes = (from pd in dc.tblOrders
                                      orderby pd.OrderDate
                                      join c in dc.tblCustomers on pd.CustomerId equals c.Id
                                      select new
                                      {
                                          Id = pd.Id,
                                          OrderDate = pd.OrderDate,
                                          CustomerId = pd.CustomerId,
                                          //ShipDate = pd.ShipDate,
                                          CustomerName = c.Firstname + " " + c.Lastname

                                      }).ToList();
                orderes.ForEach(pd => rows.Add(new Order
                {
                    Id = pd.Id,
                    OrderDate = pd.OrderDate,
                    CustomerId = pd.CustomerId,
                    //ShipDate = pd.ShipDate,
                    //CustomerName = pd.CustomerName,

                }));
            }
            return rows;
        }

        public int Delete(Guid id, bool rollback = false)
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
