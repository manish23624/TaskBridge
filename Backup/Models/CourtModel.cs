using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class CourtModel
    {
        public string CourtName { get; set; }
        public int CourtCode { get; set; }
    }
    public class CourtResult
    {
        public int CourtType { get; set; }
        public int CourtCode { get; set; }
        public string CaseNo { get; set; }

    }
}
