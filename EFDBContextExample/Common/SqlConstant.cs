using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFDBContextExample.Common
{
    public class SqlConstant
    {
        /// <summary>
        /// The varchar maximum size
        /// </summary>
        public const int VARCHARMAXSIZE = 8000;

        /// <summary>
        /// The code
        /// </summary>
        public const string ID = "@Id";

        /// <summary>
        /// The message
        /// </summary>
        public const string ISSEARCH = "@IsSearch";

        /// <summary>
        /// The pageno
        /// </summary>
        public const string LIMIT = "@Limit";

        /// <summary>
        /// The pagesize
        /// </summary>
        public const string OFFSET = "@Offset";

        /// <summary>
        /// The sortorder
        /// </summary>
        public const string SORTORDER = "@SortOrder";

        /// <summary>
        /// The sortby
        /// </summary>
        public const string SORTBY = "@SortBy";

        /// <summary>
        /// The emailaddress
        /// </summary>
        public const string EMAILADDRESS = "@EmailAddress";

        /// <summary>
        /// The password
        /// </summary>
        public const string PASSWORD = "@Password";

        /// <summary>
        /// The password
        /// </summary>
        public const string NEWPASSWORD = "@NewPassword";

        /// <summary>
        /// The oldpassword
        /// </summary>
        public const string OLDPASSWORD = "@OldPassword";

        /// <summary>
        /// The upsert user allocation
        /// </summary>
        public const string USERLOG = "dbo.GetLoggingData @StartDt, @EndDt, @Level, @UserId, @Id, @IsSearch, @PageNo, @TotalRows";
    }
}