﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.PL;
using SDG.SpookyWisconsin.PL.Entities;
using SGD.SpookyWisconsin.BL;
using System.Xml.Linq;

namespace SDG.SpookyWisconsin.BL
{
    public class HauntedEventManager : GenericManager<tblHauntedEvent>
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";
        //injecting the connection string 
        public HauntedEventManager(DbContextOptions<SpookyWisconsinEntities> options) : base(options)
        {

        }

        public int Insert(HauntedEvent hauntedEvent, bool rollback = false)
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
                    row.ParticipantId = hauntedEvent.ParticipantId;
                    row.Date = hauntedEvent.Date;
                    row.Description = hauntedEvent.Description;


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
        public int Update(HauntedEvent hauntedEvent, bool rollback = false)
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
                    row.ParticipantId = hauntedEvent.ParticipantId;
                    row.Date = hauntedEvent.Date;
                    row.Description = hauntedEvent.Description;

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

        public HauntedEvent LoadById(Guid id)
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
                                   ParticipantId = pd.ParticipantId,
                                   LocationName = l.Name,
                                   Date = pd.Date,
                                   Description = pd.Description

                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new HauntedEvent
                        {
                            Id = row.Id,
                            HauntedLocationId= row.HauntedLocationId,
                            ParticipantId = row.ParticipantId,
                            LocationName = row.LocationName,
                            Date = row.Date,
                            Description = row.Description
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

        public List<HauntedEvent> Load()
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
                                      ParticipantId = pd.ParticipantId,
                                      LocationName = l.Name,
                                      Date = pd.Date,
                                      Description = pd.Description
                                  }).ToList();
                hauntedEventes.ForEach(pd => rows.Add(new HauntedEvent
                {
                    Id = pd.Id,
                    HauntedLocationId = pd.HauntedLocationId,
                    ParticipantId = pd.ParticipantId,
                    LocationName = pd.LocationName,
                    Date = pd.Date,
                    Description = pd.Description
                }));
            }
            return rows;
        }

        public int Delete(Guid id, bool rollback = false)
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
