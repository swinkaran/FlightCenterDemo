using NHibernate;
using NHibernate.Cfg;
using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace Srikaran.ARFlights.Data.Reader
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            
            //var configurationPath = HttpContext.Current.Server.MapPath(@"~\Models\hibernate.cfg.xml");
            //configuration.Configure(configurationPath);
            //var bookConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Mappings\Book.hbm.xml");
            //configuration.AddFile(bookConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
