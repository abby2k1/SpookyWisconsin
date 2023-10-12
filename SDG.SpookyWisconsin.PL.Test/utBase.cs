﻿using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDG.SpookyWisconsin.PL.Test
{
    [TestClass]
    public abstract class utBase
    {
        protected SpookyWisconsinEntities sc;
        protected IDbContextTransaction transaction;
        private IConfigurationRoot _configuration;

        // represent the database configuration
        protected DbContextOptions<SpookyWisconsinEntities> options;

        public utBase()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _configuration = builder.Build();

            options = new DbContextOptionsBuilder<SpookyWisconsinEntities>()
                .UseSqlServer(_configuration.GetConnectionString("SpookyWisconsinConnection"))
                .Options;

            sc = new SpookyWisconsinEntities();

        }

        [TestInitialize]
        public void TestInitialize()
        {
            transaction = sc.Database.BeginTransaction();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            transaction.Rollback();
            transaction.Dispose();
            sc = null;
        }

    }
}
