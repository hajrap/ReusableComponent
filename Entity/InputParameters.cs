using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class InputParameters
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Level { get; set; }
        public string UserId { get; set; }
        public int Id { get; set; }
        public bool IsSearch { get; set; }
        public int PageNo { get; set; }
        public int TotalRow { get; set; }
    }
}
