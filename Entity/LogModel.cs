using System.Collections.Generic;

namespace Entity
{
    public class LogModel
    {
        public List<UserLog> Data { get; set; }
        public InputParameters Parameters{ get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
        
        public LogModel()
        {
            Data = new List<UserLog>();
            Parameters = new InputParameters();
        }
    }
}