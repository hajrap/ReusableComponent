using EFDBContextExample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDBContextExample.Interfaces
{
    public interface IUserLog
    {
        List<UserLog> GetAllLog();
    }
}
