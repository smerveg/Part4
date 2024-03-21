using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebAPI.Domain.Entities
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public DateTime PurchaseDate { get; set; }

        //
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<PurchaseBook> PurchaseBooks { get; set; }
    }
}
