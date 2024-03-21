using BookStoreWebAPI.Application.DTOs;
using BookStoreWebAPI.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseRepository _repository;

        public PurchaseController(IPurchaseRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public  PurchaseResponseDTO Purchase(PurchaseRequestDTO request)
        {
            PurchaseResponseDTO response = new PurchaseResponseDTO();

            response = _repository.Purchase(request);
            _repository.AddPurchaseBook(response.PurchaseID, request.BookList);
            return response;
        }
    }
}
