using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using Services;

namespace DSassesment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
        private ProuductService _prouductService;
        public ProductController(ProuductService prouductService)
        {
            _prouductService = prouductService;
            
        }
        [HttpPost("Add-Product")]
        public int Post( string name, int price,int balance) {
            var p =_prouductService.AddProduct(name,price,balance);
            return p.Id;
            
        }
    }
}
