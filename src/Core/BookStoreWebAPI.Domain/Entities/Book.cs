using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebAPI.Domain.Entities
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public float Price { get; set; }

        //
        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<PurchaseBook> PurchaseBooks { get; set; }
    }
}
