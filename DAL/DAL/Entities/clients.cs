using System;
using System.Collections.Generic;
using System.Text;

namespace notarius.DAL.Entities
{
    public class clients
    {
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string Activite { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
    }
}
