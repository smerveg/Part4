using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebAPI.Application.DTOs
{
    public class PurchaseRequestDTO
    {
        public CustomerDTO CustomerInfo { get; set; }
        public List<BookDTO> BookList { get; set; }
    }
}
