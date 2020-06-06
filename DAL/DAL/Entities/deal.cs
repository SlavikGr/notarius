using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    class deal
    {
        public int DealID { get; set; }
        public int ClientID { get; set; }
        public string DealDate { get; set; }
        public double Summa { get; set; }
    }
}
