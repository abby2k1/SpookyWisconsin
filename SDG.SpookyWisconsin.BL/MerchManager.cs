using Microsoft.EntityFrameworkCore.Storage;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.PL;
using SDG.SpookyWisconsin.PL.Entities;
using System.Xml.Linq;

namespace SDG.SpookyWisconsin.BL
{
    public class MerchManager
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";

        public static int Insert(Merch merch, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblMerch row = new tblMerch();
                    //Fill the table - TODO: Fill in other columns when the database is connected
                    row.Id = new Guid();
                    row.MerchName = merch.MerchName;
                    row.InStkQty = merch.InStkQty;
                    row.Description = merch.Description;
                    row.Cost = merch.Cost;


                    merch.Id = row.Id;
                    dc.tblMerches.Add(row);
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
        public static int Update(Merch merch, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblMerch row = dc.tblMerches.FirstOrDefault(d => d.Id == merch.Id);

                    row.MerchName = merch.MerchName;
                    row.InStkQty = merch.InStkQty;
                    row.Description = merch.Description;
                    row.Cost = merch.Cost;

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

        public static Merch LoadById(Guid id)
        {
            try
            {
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    var row = (from pd in dc.tblMerches
                               where pd.Id == id
                               select new
                               {
                                   Id = pd.Id,
                                   MerchName = pd.MerchName,
                                   InStkQty = pd.InStkQty,
                                   Description = pd.Description,
                                   Cost = pd.Cost

                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new Merch
                        {
                            Id = row.Id,
                            MerchName = row.MerchName,
                            InStkQty = row.InStkQty,
                            Description = row.Description,
                            Cost = row.Cost
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

        public static List<Merch> Load()
        {
            List<Merch> rows = new List<Merch>();

            using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
            {
                var merches = (from pd in dc.tblMerches
                                      orderby pd.FirstName
                                      select new
                                      {
                                          Id = pd.Id,
                                          MerchName = pd.MerchName,
                                          InStkQty = pd.InStkQty,
                                          Description = pd.Description,
                                          Cost = pd.Cost

                                      }).ToList();
                merches.ForEach(pd => rows.Add(new Merch
                {
                    Id = pd.Id,
                    MerchName = pd.MerchName,
                    InStkQty = pd.InStkQty,
                    Description = pd.Description,
                    Cost = pd.Cost
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

                    tblMerch row = dc.tblMerches.FirstOrDefault(d => d.Id == id);

                    dc.tblMerches.Remove(row);
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
