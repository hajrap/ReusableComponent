using Entity;
using DALServices.Interfaces;
using Ninject;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace EFDBContextExample.Controllers
{
    public class LogController : Controller
    {
        private readonly IUserLog userlog;
        //private readonly IRepository<UserLog> logs;

        public LogController()
        {
            StandardKernel _kernal = new StandardKernel();
            _kernal.Load(Assembly.GetExecutingAssembly());
            IUserLog ulog = _kernal.Get<IUserLog>();
            this.userlog = ulog;
        }

        public ActionResult Index()
        {
            InputParameters param = new InputParameters();
            param.StartDate = string.Empty;
            param.EndDate = string.Empty;

            List<UserLog> result = userlog.GetLogData(param);
            return View(result);
        }
    }
}