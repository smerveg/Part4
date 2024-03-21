using BookStoreWebAPI.Application.DTOs;
using BookStoreWebAPI.Application.Interfaces;
using BookStoreWebAPI.Domain.Entities;
using BookStoreWebAPI.Persistence.Context;
using BookStoreWebAPI.Persistence.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebAPI.Persistence.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly BookStoreContext _context;

        public PurchaseRepository(BookStoreContext context)
        {
            _context = context;
        }

        //Calssification ve amount miktarına göre discount amount miktarı hesaplanmaktadır.
        private float CalculateDiscount(float amount,int customerClassification)
        {
            float discountedAmount = 0;
            switch (customerClassification)
            {
                case (int)ClassificationEnum.Regular:
                    discountedAmount=0;
                    break;                   
                case (int)ClassificationEnum.Premium:
                    discountedAmount = (amount * 10) / 100;
                    break;
                case (int)ClassificationEnum.Employee:
                    discountedAmount = (amount * 30) / 100;
                    break;
                default:
                    break;
            }

            return discountedAmount;
        }

        //Cutomer classification işlemi yapılmaktadır. Eğer bir customer employee ise discount miktarı en yüksek
        //olduğu için premium olabilecek şartları sağlıyor olsa bile classification değeri değişmemektedir.
        //Eğer customer employee değil ise geçmiş alış-verişlerine göre classification işlemi yapılmaktadır.
        private int ClassifyCustomer(int customerId)
        {
            var emplooyeCheck = _context.Customers.Find(customerId);

            int classification = (int)ClassificationEnum.Employee;

            if (emplooyeCheck.Classification!= classification)
            {
                var result = (from p in _context.Purchases
                              join pb in _context.PurchaseBook on p.PurchaseID equals pb.PurchaseID
                              join b in _context.Books on pb.BookID equals b.BookID
                              where p.CustomerID == customerId & (DateTime.Now.AddDays(-30)) < p.PurchaseDate
                              select new
                              {
                                  CustomerId = customerId,
                                  PurchaseId = p.PurchaseID,
                                  BookId = b.BookID,
                                  Price = b.Price,
                                  Quantity = pb.Quantity
                              }).ToList();

                float sum = 0;


                foreach (var item in result)
                {
                    sum += item.Price * item.Quantity;
                }
                if (sum > 100)
                {
                    classification = (int)ClassificationEnum.Premium;
                }
                else
                {
                    classification = (int)ClassificationEnum.Regular;
                }
            }

            

            return c;


        }

        private float GetBookPrice(int bookId)
        {
            return _context.Books.Find(bookId).Price;
        }

        //Gerekli hespalamalar yapıldıktan sonra Purchase tablosuna kayıt yapılmaktadır.
        public  PurchaseResponseDTO Purchase(PurchaseRequestDTO purchase)
        {
            PurchaseResponseDTO purchaseInfo = new PurchaseResponseDTO();
            float totalAmount = 0;

            int customerClassification = ClassifyCustomer(purchase.CustomerInfo.CustomerID);
           
            foreach (var item in purchase.BookList)
            {
                item.Price = GetBookPrice(item.BookID);
                totalAmount+=(item.Quantity) * (item.Price);
            }

            purchaseInfo.OriginalPrice = totalAmount;
            purchaseInfo.DiscountedAmount = CalculateDiscount(totalAmount, customerClassification);
            purchaseInfo.FinalPrice = purchaseInfo.OriginalPrice - purchaseInfo.DiscountedAmount;

            Purchase p = new Purchase();
            p.PurchaseDate = DateTime.Now;
            p.CustomerID = purchase.CustomerInfo.CustomerID;
            _context.Purchases.Add(p);
            _context.SaveChanges();
            purchaseInfo.PurchaseID = p.PurchaseID;

            return  purchaseInfo;


        }

        //PurchaseBook tablosuna kayıt yapılmaktadır.
        public void AddPurchaseBook(int purchaseId, List<BookDTO> bookList)
        {

            List<PurchaseBook> list = new List<PurchaseBook>();
            foreach (var item in bookList)
            {
                PurchaseBook pb = new PurchaseBook()
                {
                    BookID = item.BookID,
                    PurchaseID = purchaseId,
                    Quantity = item.Quantity

                };

                list.Add(pb);

            }

            _context.PurchaseBook.AddRange(list);
            _context.SaveChanges();
           
            
            //    Purchase eposta = new Purchase { PurchaseID = purchaseId };
            //    eposta.Books = new List<Book>();
            //    _context.Purchases.Add(eposta);
            //    _context.Purchases.Attach(eposta);


            //    foreach (var item in bookList)
            //    {
                    
            //        Book kisi = new Book { BookID = item.BookID };
            //        _context.Books.Add(kisi);
            //        _context.Books.Attach(kisi);


            //        eposta.Books.Add(kisi);
            //    }


            //_context.SaveChangesAsync();

            }
        
    }
}
