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
    public class TierManager
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";

        public static int Insert(Tier tier, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblTier row = new tblTier();
                    //Fill the table - TODO: Fill in other columns when the database is connected
                    row.Id = new Guid();


                    tier.Id = row.Id;
                    dc.tblTier.Add(row);
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
        public static int Update(Tier tier, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblTier row = dc.tblTier.FirstOrDefault(d => d.Id == tier.Id);

                    //TODO: Fill in the updated fields once the database is completed
                    //ex: row.State = tier.State...


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

        public static Tier LoadById(int id)
        {
            try
            {
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    var row = (from pd in dc.tblTier
                               where pd.Id == id
                               select new
                               {
                                   Id = pd.Id,
                                   //TODO - Joins and other fields

                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new Tier
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

        public static List<Tier> Load()
        {
            List<Tier> rows = new List<Tier>();

            using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
            {
                var tieres = (from pd in dc.tblTier
                                      orderby pd.FirstName
                                      select new
                                      {
                                          Id = pd.Id,
                                          //TODO - Joins and other fields

                                      }).ToList();
                tieres.ForEach(pd => rows.Add(new Tier
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

                    tblTier row = dc.tblTier.FirstOrDefault(d => d.Id == id);

                    dc.tblTier.Remove(row);
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
