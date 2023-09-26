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
    public class HauntedEventManager
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";

        public static int Insert(HauntedEvent hauntedEvent, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblHauntedEvent row = new tblHauntedEvent();
                    //Fill the table - TODO: Fill in other columns when the database is connected
                    row.Id = new Guid();


                    hauntedEvent.Id = row.Id;
                    dc.tblHauntedEvent.Add(row);
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
        public static int Update(HauntedEvent hauntedEvent, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblHauntedEvent row = dc.tblHauntedEvent.FirstOrDefault(d => d.Id == hauntedEvent.Id);

                    //TODO: Fill in the updated fields once the database is completed
                    //ex: row.State = hauntedEvent.State...


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

        public static HauntedEvent LoadById(int id)
        {
            try
            {
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    var row = (from pd in dc.tblHauntedEvent
                               where pd.Id == id
                               select new
                               {
                                   Id = pd.Id,
                                   //TODO - Joins and other fields

                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new HauntedEvent
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

        public static List<HauntedEvent> Load()
        {
            List<HauntedEvent> rows = new List<HauntedEvent>();

            using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
            {
                var hauntedEventes = (from pd in dc.tblHauntedEvent
                                  orderby pd.FirstName
                                  select new
                                  {
                                      Id = pd.Id,
                                      //TODO - Joins and other fields

                                  }).ToList();
                hauntedEventes.ForEach(pd => rows.Add(new HauntedEvent
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

                    tblHauntedEvent row = dc.tblHauntedEvent.FirstOrDefault(d => d.Id == id);

                    dc.tblHauntedEvent.Remove(row);
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
