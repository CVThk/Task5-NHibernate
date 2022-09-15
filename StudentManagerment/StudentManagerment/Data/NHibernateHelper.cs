using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using StudentManagerment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagerment.Data
{
    public class NHibernateHelper
    {
        //private static string _connectionString = @"Data Source=CVTHINH\SQLEXPRESS;Initial Catalog=StudentManagerment;Integrated Security=True";
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory(); return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()

             .Database(MsSqlConfiguration.MsSql2012.ConnectionString(
                @"Data Source=CVTHINH\SQLEXPRESS;Initial Catalog=StudentManagerment;Integrated Security=True").ShowSql())

             .Mappings(m => m.FluentMappings
                 .AddFromAssemblyOf<Student>()
                 .AddFromAssemblyOf<Subject>()
             )
             .ExposeConfiguration(cfg => new SchemaExport(cfg)
             .Create(false, false))
             .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
