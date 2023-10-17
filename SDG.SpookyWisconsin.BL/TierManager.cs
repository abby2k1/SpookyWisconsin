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
    public class TierManager : GenericManager<tblTier>
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";
        //injecting the connection string 
        public TierManager(DbContextOptions<SpookyWisconsinEntities> options) : base(options)
        {

        }

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
                    //Fill the table 
                    row.Id = new Guid();
                    row.TierLevel = tier.TierLevel;
                    row.TierName = tier.TierName;


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

                    row.TierLevel = tier.TierLevel;
                    row.TierName = tier.TierName;

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

        public static Tier LoadById(Guid id)
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
                                   TierLevel = pd.TierLevel,
                                   TierName = pd.TierName

                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new Tier
                        {
                            Id = row.Id,
                            TierLevel = row.TierLevel,
                            TierName = row.TierName
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
                                      orderby pd.TierLevel
                                      select new
                                      {
                                          Id = pd.Id,
                                          TierLevel = pd.TierLevel,
                                          TierName = pd.TierName
                                      }).ToList();
                tieres.ForEach(pd => rows.Add(new Tier
                {
                    Id = pd.Id,
                    TierLevel = pd.TierLevel,
                    TierName = pd.TierName
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
