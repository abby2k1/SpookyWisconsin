﻿using SDG.SpookyWisconsin.BL.Models;
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
using Microsoft.EntityFrameworkCore;

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
                int results2 = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblOrder row = new tblOrder();
                    //Fill the table - TODO: Fill in other columns when the database is connected
                    row.Id = Guid.NewGuid();
                    row.OrderDate = order.OrderDate;
                    row.ShipDate = order.ShipDate;
                    row.CustomerId = order.CustomerId;
                    row.UserId = order.UserId;


                    order.Id = row.Id;
                    dc.tblOrders.Add(row);
                    results = dc.SaveChanges();

                    tblOrderItem row2 = new tblOrderItem();

                    foreach (OrderItem oi in order.OrderItems)
                    {
                        row2.Id = new Guid();
                        row2.OrderId = order.Id;
                        row2.MerchId = oi.MerchId;
                        row2.Quantity = oi.Quantity;
                        row2.Cost = oi.Cost;
                        dc.tblOrderItems.Add(row2);
                        //results2 = dc.SaveChanges();
                    }
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

        public static Order LoadById(Guid id)
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
                                   CustomerName = c.FirstName + " " + c.LastName
                                   

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

        public static List<Order> Load()
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
                                          CustomerName = c.FirstName + " " + c.LastName

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
