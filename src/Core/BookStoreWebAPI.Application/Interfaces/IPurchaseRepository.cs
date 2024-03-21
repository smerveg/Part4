using BookStoreWebAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebAPI.Application.Interfaces
{
    public interface IPurchaseRepository
    {
        PurchaseResponseDTO Purchase(PurchaseRequestDTO purchase);
        void AddPurchaseBook(int purchaseId, List<BookDTO> bookList);
    }
}
