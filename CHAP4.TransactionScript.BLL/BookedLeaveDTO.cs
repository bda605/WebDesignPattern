using System;
using System.Collections.Generic;
using System.Text;

namespace CHAP4.TransactionScript.BLL
{
    public class BookedLeaveDTO
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public int DaysTaken { get; set; }
    }
}
