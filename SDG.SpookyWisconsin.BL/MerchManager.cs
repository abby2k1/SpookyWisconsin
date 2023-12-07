using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.PL;
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
                    row.Id = new Guid();
                    row.MerchName = merch.MerchName;
                    row.InStkQty = merch.InStkQty;
                    row.Description = merch.Description;
                    row.Cost = merch.Cost;
                    row.ImagePath = merch.ImagePath;


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
                    row.Description = merch.Description;
                    row.InStkQty = merch.InStkQty;
                    row.Cost = merch.Cost;
                    row.ImagePath = merch.ImagePath;

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
                    tblMerch row = dc.tblMerches.FirstOrDefault(dt => dt.Id == id);
                    if (row != null)
                    {
                        return new Merch
                        {
                            Id = row.Id,
                            MerchName = row.MerchName,
                            InStkQty = row.InStkQty,
                            Description = row.Description,
                            Cost = row.Cost,
                            ImagePath = row.ImagePath
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

        public static List<Merch> Load(Guid? merchTypeId = null)
        {
            if (merchTypeId == null)
            {
                try
                {
                    List<Merch> rows = new List<Merch>();

                    SpookyWisconsinEntities dc = new SpookyWisconsinEntities();

                    var merches = dc.tblMerches
                        .ToList();

                    merches.ForEach(m => rows.Add(new Models.Merch
                    {
                        Id = m.Id,
                        MerchName = m.MerchName,
                        Description = m.Description,
                        InStkQty = m.InStkQty,
                        Cost = m.Cost,
                        ImagePath = m.ImagePath
                    }));

                    return rows;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            else
            {
                try
                {
                    List<Merch> rows = new List<Merch>();

                    SpookyWisconsinEntities dc = new SpookyWisconsinEntities();

                    var merches = (from mg in dc.tblMerchTypeMerches
                                  join m in dc.tblMerches on mg.MerchId equals m.Id
                                  where mg.MerchTypeId == merchTypeId || merchTypeId == null
                                  orderby m.Id
                                  select new
                                  {
                                      Id = m.Id,
                                      MerchName = m.MerchName,
                                      Description = m.Description,
                                      InStkQty = m.InStkQty,
                                      Cost = m.Cost,
                                      ImagePath = m.ImagePath
                                  }).ToList();

                    merches.ForEach(m => rows.Add(new Models.Merch
                    {
                        Id = m.Id,
                        MerchName = m.MerchName,
                        Description = m.Description,
                        InStkQty = m.InStkQty,
                        Cost = m.Cost,
                        ImagePath = m.ImagePath
                    }));

                    return rows;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
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
