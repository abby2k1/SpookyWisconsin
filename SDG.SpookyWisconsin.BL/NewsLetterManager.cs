using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.PL;

namespace SDG.SpookyWisconsin.BL
{
    public class NewsLetterManager
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";

        public static int Insert(NewsLetter newsLetter, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblNewsLetter row = new tblNewsLetter();
                    //Fill the table - TODO: Fill in other columns when the database is connected
                    row.Id = new Guid();
                    row.HauntedEventId = newsLetter.HauntedEventId;
                    row.Description = newsLetter.Description;
                    row.Date = newsLetter.Date;


                    newsLetter.Id = row.Id;
                    dc.tblNewsLetters.Add(row);
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
        public static int Update(NewsLetter newsLetter, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblNewsLetter row = dc.tblNewsLetters.FirstOrDefault(d => d.Id == newsLetter.Id);

                    row.HauntedEventId = newsLetter.HauntedEventId;
                    row.Description = newsLetter.Description;
                    row.Date = newsLetter.Date;


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

        public static NewsLetter LoadById(Guid id)
        {
            try
            {
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    var row = (from pd in dc.tblNewsLetters
                               join he in dc.tblHauntedEvents on pd.HauntedEventId equals he.Id
                               where pd.Id == id
                               select new
                               {
                                   Id = pd.Id,
                                   HauntedEventId = pd.HauntedEventId,
                                   HauntedEventName = he.Name,
                                   Description = pd.Description,
                                   Date = pd.Date

                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new NewsLetter
                        {
                            Id = row.Id,
                            HauntedEventId = row.HauntedEventId,
                            HauntedEventName = row.HauntedEventName,
                            Description = row.Description,
                            Date = row.Date
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

        /// <summary>
        /// Get news letters from the database
        /// </summary>
        /// <returns>A list of the news letters and associated fields from the database</returns>
        public static List<NewsLetter> Load()
        {
            List<NewsLetter> rows = new List<NewsLetter>();

            using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
            {
                var newsLetteres = (from pd in dc.tblNewsLetters
                                    join he in dc.tblHauntedEvents on pd.HauntedEventId equals he.Id
                                      orderby pd.Date
                                      select new
                                      {
                                          Id = pd.Id,
                                          HauntedEventId = pd.HauntedEventId,
                                          HauntedEventName = he.Name,
                                          Description = pd.Description,
                                          Date = pd.Date

                                      }).ToList();
                newsLetteres.ForEach(pd => rows.Add(new NewsLetter
                {
                    Id = pd.Id,
                    HauntedEventId = pd.HauntedEventId,
                    HauntedEventName= pd.HauntedEventName,
                    Description = pd.Description,
                    Date = pd.Date
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

                    tblNewsLetter row = dc.tblNewsLetters.FirstOrDefault(d => d.Id == id);

                    dc.tblNewsLetters.Remove(row);
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
