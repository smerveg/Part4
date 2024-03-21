using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebAPI.Domain.Entities
{
    public class PurchaseBook
    {
        public int PurchaseBookID { get; set; }
        public int BookID { get; set; }
        public int PurchaseID { get; set; }
        public int Quantity { get; set; }
    }
}
