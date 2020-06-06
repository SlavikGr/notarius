using System;
using System.Collections.Generic;
using System.Text;

namespace notarius.DAL.Entities
{
    public class deal
    {
        public int DealID { get; set; }
        public int ClientID { get; set; }
        public string DealDate { get; set; }
        public double Summa { get; set; }
    }
}
