using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.PL;
using System.Xml.Linq;

namespace SDG.SpookyWisconsin.BL
{
    public class HauntedLocationManager
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";

        public static int Insert(HauntedLocation hauntedLocation, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblHauntedLocation row = new tblHauntedLocation();
                    //Fill the table - TODO: Fill in other columns when the database is connected
                    row.Id = new Guid();
                    row.AddressId = hauntedLocation.AddressId;
                    row.Name = hauntedLocation.Name;

                    hauntedLocation.Id = row.Id;
                    dc.tblHauntedLocations.Add(row);
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
        public static int Update(HauntedLocation hauntedLocation, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblHauntedLocation row = dc.tblHauntedLocations.FirstOrDefault(d => d.Id == hauntedLocation.Id);

                    row.AddressId = hauntedLocation.AddressId;
                    row.Name = hauntedLocation.Name;


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

        public static HauntedLocation LoadById(Guid id)
        {
            try
            {
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    var row = (from pd in dc.tblHauntedLocations
                               join a in dc.tblAddresses on pd.AddressId equals a.Id
                               where pd.Id == id
                               select new
                               {
                                   Id = pd.Id,
                                   Name = pd.Name,
                                   AddressId = pd.AddressId,
                                   Address = a.Street + " " + a.City + ", " + a.State

                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new HauntedLocation
                        {
                            Id = row.Id,
                            Name = row.Name,
                            AddressId = row.AddressId,
                            Address = row.Address
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

        public static List<HauntedLocation> Load()
        {
            List<HauntedLocation> rows = new List<HauntedLocation>();

            using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
            {
                var hauntedLocationes = (from pd in dc.tblHauntedLocations
                                         join a in dc.tblAddresses on pd.AddressId equals a.Id
                                         orderby pd.Id
                                      select new
                                      {
                                          Id = pd.Id,
                                          Name = pd.Name,
                                          AddressId = pd.AddressId,
                                          Address = a.Street + " " + a.City + ", " + a.State
                                          

                                      }).ToList();
                hauntedLocationes.ForEach(pd => rows.Add(new HauntedLocation
                {
                    Id = pd.Id,
                    Name = pd.Name,
                    AddressId = pd.AddressId,
                    Address = pd.Address
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

                    tblHauntedLocation row = dc.tblHauntedLocations.FirstOrDefault(d => d.Id == id);

                    dc.tblHauntedLocations.Remove(row);
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
