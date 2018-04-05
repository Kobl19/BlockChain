using Domain.Interfaces;
using Domain.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Infastracture
{
    public class ServiceModule:NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IRepository>().To<Repository>().WithConstructorArgument(connectionString);
        }
    }
}
