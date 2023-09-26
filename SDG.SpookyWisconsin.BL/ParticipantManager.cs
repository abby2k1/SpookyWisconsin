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


namespace SDG.SpookyWisconsin.BL
{
    public class ParticipantManager
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";

        public static int Insert(Participant participant, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblParticipant row = new tblParticipant();
                    //Fill the table - TODO: Fill in other columns when the database is connected
                    row.Id = new Guid();


                    participant.Id = row.Id;
                    dc.tblParticipant.Add(row);
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
        public static int Update(Participant participant, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblParticipant row = dc.tblParticipant.FirstOrDefault(d => d.Id == participant.Id);

                    //TODO: Fill in the updated fields once the database is completed
                    //ex: row.State = participant.State...


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

        public static Participant LoadById(int id)
        {
            try
            {
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    var row = (from pd in dc.tblParticipant
                               where pd.Id == id
                               select new
                               {
                                   Id = pd.Id,
                                   //TODO - Joins and other fields

                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new Participant
                        {
                            Id = row.Id,
                            ///TODO - Joins and other fields
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

        public static List<Participant> Load()
        {
            List<Participant> rows = new List<Participant>();

            using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
            {
                var participantes = (from pd in dc.tblParticipant
                                      orderby pd.FirstName
                                      select new
                                      {
                                          Id = pd.Id,
                                          //TODO - Joins and other fields

                                      }).ToList();
                participantes.ForEach(pd => rows.Add(new Participant
                {
                    Id = pd.Id,
                    //TODO - Joins and other fields
                }));
            }
            return rows;
        }

        public static int Delete(int id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblParticipant row = dc.tblParticipant.FirstOrDefault(d => d.Id == id);

                    dc.tblParticipant.Remove(row);
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
