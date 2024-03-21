using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebAPI.Application.DTOs
{
    public class BookDTO    {
        public int BookID { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}
