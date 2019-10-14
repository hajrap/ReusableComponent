using DALServices.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Entity;
using NLog;

namespace DALServices.DAL
{
    public class LogService : IUserLog
    {
        ASGWebLogEntities db = new ASGWebLogEntities();
        Logger loggerx = LogManager.GetCurrentClassLogger();

        public LogModel GetLog(InputParameters param)
        {
            LogModel result = new LogModel();
            param.TotalRow= 2;
            if(param.PageNo == 0)
            {
                param.PageNo = 1;
            }
            IEnumerable<NLog_Error> logResult = null;

            try
            {
                if (param.IsSearch == true)
                {
                    var data = (from log in db.GetLoggingData(param.IsSearch, param.StartDate,
                                            param.EndDate, param.Level, param.UserId,
                                            param.Id, param.PageNo, param.TotalRow)
                                    select new GetLoggingData_Result {
                                        Id = log.Id,
                                        TimeStamp = log.TimeStamp,
                                        Level = log.Level,
                                        Host = log.Host,
                                        Type = log.Type,
                                        Logger = log.Logger,
                                        Message = log.Message,
                                        stacktrace = log.stacktrace,
                                        TotalCount = log.TotalCount
                                });

                    result.Data = (from a in data
                                   select new UserLog
                                   {
                                       Id = a.Id,
                                       Host = a.Host,
                                       Error = a.stacktrace,
                                       TotalCount = Convert.ToInt32(a.TotalCount)
                                   }).ToList();

                    int count = Convert.ToInt32(result.Data.Select(z=>z.TotalCount).FirstOrDefault());

                    double pageCount = (double)((decimal)count / Convert.ToDecimal(param.TotalRow));
                    result.PageCount = (int)Math.Ceiling(pageCount);
                    result.Parameters = param;
                }
                else
                {
                    var data = (from log in db.NLog_Error
                            select log)
                                .OrderByDescending(x => x.TimeStamp)
                                .Skip((param.PageNo - 1) * param.TotalRow)
                                .Take(param.TotalRow);

                    double pageCount = (double)((decimal)db.NLog_Error.Count() / Convert.ToDecimal(param.TotalRow));
                    result.PageCount = (int)Math.Ceiling(pageCount);

                    result.Data = (from a in data
                                   select new UserLog
                                   {
                                       Id = a.Id,
                                       Host = a.Host,
                                       Error = a.stacktrace
                                   }).ToList();
                }

                result.CurrentPageIndex = param.PageNo;
               
            }
            catch (Exception ex)
            {
                //loggerx.SetProperty("MemberId", "12121212");
                loggerx.Error(ex);
            }
            return result;
        }

        public List<UserLog> GetLogData(InputParameters param)
        {
            var data = db.GetLoggingData(param.IsSearch, param.StartDate, 
                                        param.EndDate, param.Level, param.UserId,
                                        param.Id, param.PageNo, param.TotalRow);

            List<UserLog> uLog = (from a in data
                                  select new UserLog
                                  {
                                      Id = a.Id,
                                      Host = a.Host,
                                      Error = a.Message
                                  }).ToList();
            return uLog;
        }

        public UserLog GetLogDetail(int id)
        {
            try
            {
                var data = (from a in db.NLog_Error
                            where id == a.Id
                            select new UserLog
                            {
                                Id = a.Id,
                                Host = a.Host,
                                Error = a.Message
                            }).FirstOrDefault();

                return data;
            }
            catch (Exception ex)
            {
                loggerx.Error(ex);
                return null;
            }
        }

    }
}