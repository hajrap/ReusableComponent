using Entity;
using DALServices.Interfaces;
using System.Web.Mvc;
using Ninject;
using System.Reflection;
using System.Collections.Generic;

namespace EFDBContextExample.Controllers
{
    public class UserLogController : Controller
    {
        // GET: UserLog
        private readonly IUserLog userlog;
        //private readonly IRepository<UserLog> logs;

        public UserLogController()
        {
            StandardKernel _kernal = new StandardKernel();
            _kernal.Load(Assembly.GetExecutingAssembly());
            IUserLog ulog = _kernal.Get<IUserLog>();
            this.userlog = ulog;
        }

        public ActionResult Index(InputParameters param = null)
        {
            return View(userlog.GetLog(param));
        }

        //public LogModel GetLogData(int currentPage)
        //{
        //    InputParameters param = new InputParameters();
        //    param.TotalRow = 10;
        //    param.PageNo = currentPage;
        //    param.IsSearch = false;
        //    //param.StartDate = string.Empty;
        //    //param.EndDate= string.Empty;
        //    //param.Level = string.Empty;
        //    //param.UserId = string.Empty;
        //    //param.Id = 0;
        //    //double pageCount = (double)((decimal)userlog.Count() / Convert.ToDecimal(maxRows));
        //    //LogModel.PageCount = (int)Math.Ceiling(pageCount);

        //    LogModel result = new LogModel();
        //    result = userlog.GetLog(param);
        //    return result;
        //}

        public JsonResult GetLogDetail(int id)
        {
            return Json(userlog.GetLogDetail(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchErrorLogs(InputParameters searchParam)
        {
            return Json(userlog.GetLog(searchParam), JsonRequestBehavior.AllowGet);
        }
    }
}