﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.PL;
using System.Xml.Linq;

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
                    row.HauntedLocationId = hauntedEvent.HauntedLocationId;
                    row.Date = hauntedEvent.Date;
                    row.Description = hauntedEvent.Description;
                    row.ImagePath = hauntedEvent.ImagePath;


                    hauntedEvent.Id = row.Id;
                    dc.tblHauntedEvents.Add(row);
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

                    tblHauntedEvent row = dc.tblHauntedEvents.FirstOrDefault(d => d.Id == hauntedEvent.Id);

                    row.HauntedLocationId = hauntedEvent.HauntedLocationId;
                    row.Date = hauntedEvent.Date;
                    row.Description = hauntedEvent.Description;
                    row.ImagePath = hauntedEvent.ImagePath;

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

        public static HauntedEvent LoadById(Guid id)
        {
            try
            {
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    var row = (from pd in dc.tblHauntedEvents
                               join l in dc.tblHauntedLocations on pd.HauntedLocationId equals l.Id 
                               where pd.Id == id
                               select new
                               {
                                   Id = pd.Id,
                                   HauntedLocationId = pd.HauntedLocationId,
                                   LocationName = l.Name,
                                   Date = pd.Date,
                                   Description = pd.Description,
                                   ImagePath = pd.ImagePath

                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new HauntedEvent
                        {
                            Id = row.Id,
                            HauntedLocationId= row.HauntedLocationId,
                            LocationName = row.LocationName,
                            Date = row.Date,
                            Description = row.Description,
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

        public static List<HauntedEvent> Load()
        {
            List<HauntedEvent> rows = new List<HauntedEvent>();

            using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
            {
                var hauntedEventes = (from pd in dc.tblHauntedEvents
                                      join l in dc.tblHauntedLocations on pd.HauntedLocationId equals l.Id
                                      orderby pd.Date
                                  select new
                                  {
                                      Id = pd.Id,
                                      HauntedLocationId = pd.HauntedLocationId,
                                      LocationName = l.Name,
                                      Date = pd.Date,
                                      Description = pd.Description,
                                      ImagePath = pd.ImagePath
                                  }).ToList();
                hauntedEventes.ForEach(pd => rows.Add(new HauntedEvent
                {
                    Id = pd.Id,
                    HauntedLocationId = pd.HauntedLocationId,
                    LocationName = pd.LocationName,
                    Date = pd.Date,
                    Description = pd.Description,
                    ImagePath = pd.ImagePath
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

                    tblHauntedEvent row = dc.tblHauntedEvents.FirstOrDefault(d => d.Id == id);

                    dc.tblHauntedEvents.Remove(row);
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
