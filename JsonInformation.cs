using System;
using System.Collections.Generic;
using System.Text;

namespace CrawlWalmart.Data
{
    public class JsonInformation
    {
        public Account Account { get; set; }
        public List<OrderInformation> OrderInformations { get; set; } = new List<OrderInformation>();
        public string Address { get; set; }
        public string CreditCard { get; set; }
    }
}
