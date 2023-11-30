using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.PL;
using SDG.SpookyWisconsin.PL.Entities;
using SGD.SpookyWisconsin.BL;

namespace SDG.SpookyWisconsin.BL
{
    public class TourManager : GenericManager<tblTour>
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";
        //injecting the connection string 
        public TourManager(DbContextOptions<SpookyWisconsinEntities> options) : base(options)
        {

        }
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
                               join l in dc.tblHauntedLocations on pd.HauntedLocationId equals l.Id
                               where pd.Id == id
                               select new
                               {
                                   Id = pd.Id,
                                   HauntedLocationId = pd.HauntedLocationId,
                                   LocationName = l.Name,
                                   Description = pd.Description,
                                   TourName = pd.TourName,


                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new Tour
                        {
                            Id = row.Id,
                            HauntedLocationId = row.HauntedLocationId,
                            LocationName = row.LocationName,
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
                              join l in dc.tblHauntedLocations on pd.HauntedLocationId equals l.Id
                              orderby pd.TourName
                                      select new
                                      {
                                          Id = pd.Id,
                                          HauntedLocationId = pd.HauntedLocationId,
                                          LocationName = l.Name,
                                          TourName = pd.TourName,
                                          Description = pd.Description
                                          //TODO - Joins and other fields

                                      }).ToList();
                toures.ForEach(pd => rows.Add(new Tour
                {
                    Id = pd.Id,
                    HauntedLocationId = pd.HauntedLocationId,
                    LocationName = pd.LocationName,
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

        public static int Delete(Guid id, Tour tour)
        {
            throw new NotImplementedException();
        }
    }
}
