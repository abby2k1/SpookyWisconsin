using Microsoft.EntityFrameworkCore.Storage;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.PL;
using SDG.SpookyWisconsin.PL.Entities;
using System.Xml.Linq;

namespace SDG.SpookyWisconsin.BL
{
    public class MemberManager
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";

        public static int Insert(Member member, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblMember row = new tblMember();
                    //Fill the table
                    row.Id = new Guid();
                    row.TierId = member.TierId;
                    row.NewsLetterId = member.NewsLetterId;
                    row.MemberOpt = member.MemberOpt;
                    row.NewsLetterOpt = member.NewsLetterOpt;


                    member.Id = row.Id;
                    dc.tblMemberships.Add(row);
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
        public static int Update(Member member, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblMember row = dc.tblMemberships.FirstOrDefault(d => d.Id == member.Id);

                    row.TierId = member.TierId;
                    row.NewsLetterId = member.NewsLetterId;
                    row.MemberOpt = member.MemberOpt;
                    row.NewsLetterOpt = member.NewsLetterOpt;

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

        public static Member LoadById(Guid id)
        {
            try
            {
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    var row = (from pd in dc.tblMemberships
                               where pd.Id == id
                               select new
                               {
                                   Id = pd.Id,
                                   TierId = pd.TierId,
                                   NewsLetterId = pd.NewsLetterId,
                                   MemberOpt = pd.MemberOpt,
                                   NewsLetterOpt = pd.NewsLetterOpt

                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new Member
                        {
                            Id = row.Id,
                            TierId= row.TierId,
                            NewsLetterId = row.NewsLetterId,
                            MemberOpt = row.MemberOpt,
                            NewsLetterOpt = row.NewsLetterOpt
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

        public static List<Member> Load()
        {
            List<Member> rows = new List<Member>();

            using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
            {
                var memberes = (from pd in dc.tblMemberships
                                      orderby pd.Id
                                      select new
                                      {
                                          Id = pd.Id,
                                          TierId = pd.TierId,
                                          NewsLetterId = pd.NewsLetterId,
                                          MemberOpt = pd.MemberOpt,
                                          NewsLetterOpt = pd.NewsLetterOpt

                                      }).ToList();
                memberes.ForEach(pd => rows.Add(new Member
                {
                    Id = pd.Id,
                    TierId = pd.TierId,
                    NewsLetterId = pd.NewsLetterId,
                    MemberOpt = pd.MemberOpt,
                    NewsLetterOpt = pd.NewsLetterOpt
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

                    tblMember row = dc.tblMemberships.FirstOrDefault(d => d.Id == id);

                    dc.tblMemberships.Remove(row);
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
