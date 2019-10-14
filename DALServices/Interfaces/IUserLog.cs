using Entity;
using System.Collections.Generic;

namespace DALServices.Interfaces
{
    public interface IUserLog
    {
        List<UserLog> GetLogData(InputParameters param);
        LogModel GetLog(InputParameters param);
        UserLog GetLogDetail(int id);
    }
}
