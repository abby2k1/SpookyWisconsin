﻿using Microsoft.EntityFrameworkCore.Storage;
using SDG.SpookyWisconsin.BL.Models;
using SDG.SpookyWisconsin.PL;
using SDG.SpookyWisconsin.PL.Entities;
using System.Security.Cryptography;
using System.Text;

namespace SDG.SpookyWisconsin.BL
{
    public class UserManager
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";

        public class LoginFailureException : Exception
        {
            public LoginFailureException() : base("Login Failure") { }
            public LoginFailureException(string message) : base(message) { }
        }

        private static string GetHash(string password)
        {
            using (var hasher = SHA1.Create())
            {
                var hashbytes = Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
            }
        }
        public static void Seed()
        {
            //seed is used like default data
            using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
            {
                if (!dc.tblUsers.Any())
                {
                    User user = new User
                    {
                        UserName = "cwitthuhn",
                        Password = "colbypassword"
                    };
                    Insert(user);
                    user = new User
                    {
                        UserName = "tlee",
                        Password = "thaypassword"
                    };
                    Insert(user);
                    user = new User
                    {
                        UserName = "cmarohl",
                        Password = "cadinpassword"
                    };
                    Insert(user);
                    user = new User
                    {
                        UserName = "cperez",
                        Password = "crystalpassword"
                    };
                    Insert(user);
                    user = new User
                    {
                        UserName = "athompson",
                        Password = "abbypassword"
                    };
                    Insert(user);
                    user = new User
                    {
                        UserName = "kxiong",
                        Password = "kathypassword"
                    };
                    Insert(user);
                }
            }
        }

        public static bool Login(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.UserName))
                {
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                        {
                            tblUser tblUser = dc.tblUsers.FirstOrDefault(u => u.Username == user.UserName);

                            if (tblUser != null)
                            {
                                if (tblUser.Password == GetHash(user.Password))
                                {
                                    //Valid Login
                                    user.Id = tblUser.Id;
                                    return true;
                                }
                                else
                                {
                                    throw new LoginFailureException();
                                }
                            }
                            else
                            {
                                throw new LoginFailureException("User ID not found.");
                            }
                        }
                    }
                    else
                    {
                        throw new LoginFailureException("Password was not set.");
                    }
                }
                else
                {
                    throw new LoginFailureException("UserID was not set.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int Insert(User user, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblUser row = new tblUser();
                    //Fill the table
                    row.Id = new Guid();
                    row.Username = user.UserName;
                    row.Password = user.Password;

                    user.Id = row.Id;
                    dc.tblUsers.Add(row);
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
        public static int Update(User user, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblUser row = dc.tblUsers.FirstOrDefault(d => d.Id == user.Id);
                    
                    row.Username = user.UserName;
                    row.Password = user.Password;

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

        public static User LoadById(int id)
        {
            try
            {
                using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
                {
                    var row = (from pd in dc.tblUsers
                               where pd.Id == id
                               select new
                               {
                                   Id = pd.Id,
                                   UserName = pd.Username,
                                   Password = pd.Password

                               }).FirstOrDefault();
                    if (row != null)
                    {
                        return new User
                        {
                            Id = row.Id,
                            UserName = row.UserName,
                            Password = row.Password
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

        public static List<User> Load()
        {
            List<User> rows = new List<User>();

            using (SpookyWisconsinEntities dc = new SpookyWisconsinEntities())
            {
                var useres = (from pd in dc.tblUsers
                                      orderby pd.Username
                                      select new
                                      {
                                          Id = pd.Id,
                                          UserName = pd.Username,
                                          Password = pd.Password
                                      }).ToList();
                useres.ForEach(pd => rows.Add(new User
                {
                    Id = pd.Id,
                    Password = pd.Password,
                    UserName = pd.UserName
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

                    tblUser row = dc.tblUsers.FirstOrDefault(d => d.Id == id);

                    dc.tblUsers.Remove(row);
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
