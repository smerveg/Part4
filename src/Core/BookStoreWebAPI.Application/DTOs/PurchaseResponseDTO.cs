using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebAPI.Application.DTOs
{
    public class PurchaseResponseDTO
    {
        public int PurchaseID { get; set; }
        public float OriginalPrice { get; set; }
        public float DiscountedAmount { get; set; }
        public float FinalPrice { get; set; }
    }
}
