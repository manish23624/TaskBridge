using System;

namespace Models
{
    public class HomeDashboardModel
    {
        public int TotalCase { get; set; }
        public int PendingCase { get; set; }

        public int DisposedCase { get; set; }
        public int ActiveCourts { get; set; }
        public int MonthTotal { get; set; }
    }
}
