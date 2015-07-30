using System;
using Castle.Windsor;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;

namespace GPMS.Setting
{
    public class Ioc
    {
        private static Ioc _instance;
        private static readonly object SyncRoot = new Object();
        public IWindsorContainer Container;
        private readonly ISessionFactory _sessionFactory;
        private Ioc()
        {
            Container = new WindsorContainer();

            var config = MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("DefaultConnection"));

            _sessionFactory = Fluently.Configure()
                .Database(config.ShowSql) //配置数据库
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<GPMS.Core.Mapping.SystemConfigMap>())//指定需要映射的程序集
                .CurrentSessionContext<WebSessionContext>()//Session的容器
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, false)) //配置生成数据库及表结构
                //第一个参数bool script指定是否生成数据库脚本  
                //第二个参数bool export指定每次生成的数据库的创建脚本是否执行  
                .BuildSessionFactory();  //创建session工厂
        }



        public ISessionFactory SessionFactory
        {
            get { return _sessionFactory; }
        }

        public static T Resolve<T>()
        {
            return Instance.Container.Resolve<T>();
        }

        public static Ioc Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new Ioc();
                        }
                    }
                }
                return _instance;
            }
        }

        public void StartUp(Bootstrapper bootstrapper)
        {
            bootstrapper.RegisterComponents(Container, SessionFactory);
        }
    }
}
