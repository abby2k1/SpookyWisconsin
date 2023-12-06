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
        
        public static List<Merch> Load(int? merchTypeId = null)
        {
            if (merchTypeId == null)
            {
                try
                {
                    List<Merch> rows = new List<Merch>();

                    SpookyWisconsinEntities dc = new SpookyWisconsinEntities();

                    var merchs = (from m in dc.tblMerches
                                  select new
                                  {
                                      MerchId = m.Id,
                                      MerchTitle = m.MerchName,
                                      MerchDescription = m.Description,
                                      MerchCost = m.Cost,
                                      MerchInStkQty = m.InStkQty//,
                                      //MerchImagePath = m.ImagePath
                                  }).ToList();

                    merchs.ForEach(m => rows.Add(new Models.Merch
                    {
                        Id = m.MerchId,
                        MerchName = m.MerchTitle,
                        Description = m.MerchDescription,
                        //Cost = m.MerchCost,
                        InStkQty = m.MerchInStkQty//,
                        //ImagePath = m.MerchImagePath
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
                /*try
                {
                    List<Merch> rows = new List<Merch>();

                    SpookyWisconsinEntities dc = new SpookyWisconsinEntities();

                    var merchs = (from mtm in dc.tblMerchTypeMerches
                                  join m in dc.tblMerches on mtm.MerchId equals m.Id
                                  where mtm.MerchTypeId == merchTypeId || merchTypeId == null
                                  orderby m.Id
                                  select new
                                  {
                                      MerchId = m.Id,
                                      MerchTitle = m.Title,
                                      MerchDescription = m.Description,
                                      MerchCost = m.Cost,
                                      MerchInStkQty = m.InStkQty,
                                      MerchImagePath = m.ImagePath
                                  }).ToList();

                    merchs.ForEach(m => rows.Add(new Models.Merch
                    {
                        Id = m.MerchId,
                        MerchName = m.MerchTitle,
                        Description = m.MerchDescription,
                        Cost = m.MerchCost,
                        InStkQty = m.MerchInStkQty,
                        ImagePath = m.MerchImagePath
                    }));

                    return rows;
                }
                catch (Exception e)
                {
                    return null;
                }*/
            }

            return null;
        }

        public static int Insert(Merch merch, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    //IdbContextTransaction dbContextTransaction = null;
                    //if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblMerch row = new tblMerch();
                    //Fill the table - TODO: Fill in other columns when the database is connected
                    row.Id = new Guid();
                    row.MerchName = merch.MerchName;
                    row.InStkQty = merch.InStkQty;
                    row.Description = merch.Description;
                    //row.Cost = merch.Cost;


                    merch.Id = row.Id;
                    dc.tblMerches.Add(row);
                    results = dc.SaveChanges();

                    //if (rollback) dbContextTransaction.Rollback();

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
                    //IdbContextTransaction dbContextTransaction = null;
                    //if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblMerch row = dc.tblMerches.FirstOrDefault(d => d.Id == merch.Id);

                    row.MerchName = merch.MerchName;
                    row.InStkQty = merch.InStkQty;
                    row.Description = merch.Description;
                    //row.Cost = merch.Cost;

                    results = dc.SaveChanges();

                    //if (rollback) dbContextTransaction.Rollback();

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
                            Description = row.Description//,
                            //Cost = row.Cost
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
                                      orderby pd.MerchName
                                      select new
                                      {
                                          Id = pd.Id,
                                          MerchName = pd.MerchName,
                                          InStkQty = pd.InStkQty,
                                          Description = pd.Description,
                                          Cost = (decimal)pd.Cost

                                      }).ToList();
                merches.ForEach(pd => rows.Add(new Merch
                {
                    Id = pd.Id,
                    MerchName = pd.MerchName,
                    InStkQty = pd.InStkQty,
                    Description = pd.Description,
                    Cost = (decimal)pd.Cost
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
                    //IdbContextTransaction dbContextTransaction = null;
                    //if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblMerch row = dc.tblMerches.FirstOrDefault(d => d.Id == id);

                    dc.tblMerches.Remove(row);
                    results = dc.SaveChanges();

                    //if (rollback) dbContextTransaction.Rollback();
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
