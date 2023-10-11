using Microsoft.EntityFrameworkCore.Storage;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.PL;
using SDG.SpookyWisconsin.PL.Entities;

namespace SDG.SpookyWisconsin.BL
{
    public class TourManager
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";

        public static int Insert(Tour tour, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblTour row = new tblTour();
                    //Fill the table
                    row.Id = new Guid();
                    row.HauntedLocationId = tour.HauntedLocationId;
                    row.TourName = tour.TourName;
                    row.Description = tour.Description;


                    tour.Id = row.Id;
                    dc.tblTours.Add(row);
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
        public static int Update(Tour tour, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblTour row = dc.tblTours.FirstOrDefault(d => d.Id == tour.Id);
                    row.HauntedLocationId = tour.HauntedLocationId;
                    row.Description = tour.Description;
                    row.TourName= tour.TourName;

                    //TODO: Fill in the updated fields once the database is completed
                    //ex: row.State = tour.State...


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

        public static Tour LoadById(Guid id)
        {
            try
            {
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    var row = (from pd in dc.tblTours
                               //join h in dc.tblHauntedLocations on pd.Id equals h.Id -- Join if we decide to use the location name on the tour.
                               where pd.Id == id
                               select new
                               {
                                   Id = pd.Id,
                                   HauntedLocationId = pd.HauntedLocationId,
                                   Description = pd.Description,
                                   TourName = pd.TourName,


                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new Tour
                        {
                            Id = row.Id,
                            HauntedLocationId = row.HauntedLocationId,
                            Description = row.Description,
                            TourName = row.TourName,
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

        public static List<Tour> Load()
        {
            List<Tour> rows = new List<Tour>();

            using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
            {
                var toures = (from pd in dc.tblTours
                                      orderby pd.TourName
                                      select new
                                      {
                                          Id = pd.Id,
                                          HauntedLocationId = pd.HauntedLocationId,
                                          TourName = pd.TourName,
                                          Description = pd.Description
                                          //TODO - Joins and other fields

                                      }).ToList();
                toures.ForEach(pd => rows.Add(new Tour
                {
                    Id = pd.Id,
                    HauntedLocationId = pd.HauntedLocationId,
                    TourName = pd.TourName,
                    Description = pd.Description
                    //TODO - Joins and other fields
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

                    tblTour row = dc.tblTours.FirstOrDefault(d => d.Id == id);

                    dc.tblTours.Remove(row);
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
