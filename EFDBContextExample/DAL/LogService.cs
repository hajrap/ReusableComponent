using EFDBContextExample.Common;
using EFDBContextExample.Entities;
using EFDBContextExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EFDBContextExample.DAL
{
    public class LogService : IUserLog
    {
        private readonly IRepository<UserLog> logs;

        public LogService(IRepository<UserLog> logs)
        {
            this.logs = logs;
        }

        public List<UserLog> GetAllLog()
        {
            ICollection<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(Helper.SqlInputParam(SqlConstant.ISSEARCH, "true", SqlDbType.Bit));
            var logs = this.logs.ExecWithStoreProcedure(SqlConstant.USERLOG, parameters.ToArray()).ToList();
            return logs;
        }
    }
}