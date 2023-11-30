﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.PL;
using SDG.SpookyWisconsin.PL.Entities;
using SGD.SpookyWisconsin.BL;

namespace SDG.SpookyWisconsin.BL
{
    public class ParticipantManager : GenericManager<tblParticipant>
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";
        //injecting the connection string 
        public ParticipantManager(DbContextOptions<SpookyWisconsinEntities> options) : base(options)
        {

        }

        public int Insert(Participant participant, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblParticipant row = new tblParticipant();
                    //Fill the table
                    row.Id = new Guid();
                    row.HauntedEventId = participant.HauntedEventId;
                    row.CustomerId = participant.CustomerId;


                    participant.Id = row.Id;
                    dc.tblParticipants.Add(row);
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
        public int Update(Participant participant, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblParticipant row = dc.tblParticipants.FirstOrDefault(d => d.Id == participant.Id);
                    
                    row.HauntedEventId = participant.HauntedEventId;
                    row.CustomerId = participant.CustomerId;

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

        public Participant LoadById(Guid id)
        {
            try
            {
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    var row = (from pd in dc.tblParticipants
                               join c in dc.tblCustomers on pd.CustomerId equals c.Id
                               join he in dc.tblHauntedEvents on pd.HauntedEventId equals he.Id
                               where pd.Id == id
                               select new
                               {
                                   Id = pd.Id,
                                   CustomerId = pd.CustomerId,
                                   HauntedEventId = pd.HauntedEventId,
                                   CustomerName = c.Firstname + " " + c.Lastname,
                                   HauntedEventName = he.Name

                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new Participant
                        {
                            Id = row.Id,
                            CustomerId = row.CustomerId,
                            HauntedEventId = row.HauntedEventId,
                            CustomerName = row.CustomerName,
                            HauntedEventName = row.HauntedEventName
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

        public List<Participant> Load()
        {
            List<Participant> rows = new List<Participant>();

            using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
            {
                var participantes = (from pd in dc.tblParticipants
                                     join c in dc.tblCustomers on pd.CustomerId equals c.Id
                                     join he in dc.tblHauntedEvents on pd.HauntedEventId equals he.Id
                                     orderby pd.Id
                                      select new
                                      {
                                          Id = pd.Id,
                                          CustomerId = pd.CustomerId,
                                          HauntedEventId = pd.HauntedEventId,
                                          CustomerName = c.Firstname + " " + c.Lastname,
                                          HauntedEventName = he.Name

                                      }).ToList();
                participantes.ForEach(pd => rows.Add(new Participant
                {
                    Id = pd.Id,
                    CustomerId = pd.CustomerId,
                    HauntedEventId = pd.HauntedEventId,
                    CustomerName = pd.CustomerName,
                    HauntedEventName = pd.HauntedEventName
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

                    tblParticipant row = dc.tblParticipants.FirstOrDefault(d => d.Id == id);

                    dc.tblParticipants.Remove(row);
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
