using DALServices.DAL;
using DALServices.Interfaces;
using Ninject.Modules;

namespace EFDBContextExample.App_Start
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserLog>().To<LogService>();
            //Bind<IRepository<>>().To<EFRepository<>>();
        }
    }
}